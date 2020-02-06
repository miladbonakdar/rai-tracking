using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace RaiTracking.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureSerilog(this IServiceCollection services,
            IConfiguration configuration)
        {
            var loggerSetting = configuration.GetSection(nameof(SerilogSetting))
                .Get<SerilogSetting>();
            
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(
                    Path.Combine(WebHostDefaults.ContentRootKey, loggerSetting.Path, loggerSetting.LogFileName),
                    rollingInterval: (RollingInterval) loggerSetting.RollingInterval)
                .WriteTo.Console()
                .CreateLogger();
            
            return services;
        }

        public static IServiceCollection ConfigureAppSettingsSections(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<SerilogSetting>(
                configuration.GetSection(nameof(SerilogSetting)));
            services.Configure<AuthSetting>(
                configuration.GetSection(nameof(AuthSetting)));
            services.Configure<AppSetting>(
                configuration.GetSection(nameof(AppSetting)));
            services.Configure<AppInformation>(
                configuration.GetSection(nameof(AppInformation)));
            services.Configure<CorsSetting>(
                configuration.GetSection(nameof(CorsSetting)));

            return services;
        }

        public static IServiceCollection ConfigureAppCorsSection(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<CorsSetting>(
                configuration.GetSection(nameof(CorsSetting)));

            if (!(configuration.GetSection(nameof(CorsSetting))
                .Get(typeof(CorsSetting)) is CorsSetting corsSetting))
                throw new ArgumentNullException(nameof(corsSetting));
            services.AddCors(options =>
            {
                options.AddPolicy(corsSetting.PolicyName,
                    builder =>
                    {
                        var origins = corsSetting.AllowOrigins.ToArray();
                        builder.WithOrigins(origins).AllowAnyHeader()
                            .AllowAnyMethod().AllowCredentials();
                    });
            });
            return services;
        }

        public static IServiceCollection ConfigureAppAuthentication(this IServiceCollection services,
            IConfiguration configuration)
        {
            if (!(configuration.GetSection(nameof(AuthSetting))
                .Get(typeof(AuthSetting)) is AuthSetting authSettings))
                throw new ArgumentNullException(nameof(AuthSetting));

            var key = Encoding.ASCII.GetBytes(authSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        LifetimeValidator = (before, expires, token, param)
                            => expires > DateTime.Now,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };

                    //for signal r
                    x.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                (path.StartsWithSegments($"/{UserHub.Name}"))) context.Token = accessToken;
                            return Task.CompletedTask;
                        }
                    };
                });
            return services;
        }
    }
}