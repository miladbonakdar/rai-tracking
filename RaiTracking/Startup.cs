using System.IO;
using Application.Configurations;
using Application.Interfaces;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RaiTracking.Extensions;
using RaiTracking.Middleware;
using SharedKernel.Interfaces;

namespace RaiTracking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static readonly string ApplicationPath = Directory.GetCurrentDirectory();
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureAppSettingsSections(Configuration)
                .ConfigureAppCorsSection(Configuration)
                .ConfigureAppAuthentication(Configuration);
            services.ConfigureSerilog(Configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1"
                    , new OpenApiInfo {Title = "Rai Tracking API", Version = "v1"});
            });
            
            Persistence.PersistenceModule.PgConnectionString = Configuration.GetConnectionString("postgres");
            Infrastructure.InfrastructureModule.RedisConnectionString = Configuration.GetConnectionString("redis");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ICorsSetting corsOptions)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.ConfigureExceptionHandler(env);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<IdentityProviderMiddleware>();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rai tracking API"));
            app.UseCors(corsOptions.PolicyName);
            app.UseApplicationStaticFiles(env);
        }
        public void ConfigureContainer(ContainerBuilder builder)
            => builder.RegisterApplicationComponents();
    }
}