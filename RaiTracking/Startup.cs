using Application.Configurations;
using Application.Interfaces;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using RaiTracking.Extensions;
using RaiTracking.Middleware;

namespace RaiTracking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureAppSettingsSections(Configuration)
                .ConfigureAppCorsSection(Configuration).ConfigureAppAuthentication(Configuration);
            services.ConfigureSerilog(Configuration);
            services.AddSwaggerGen(c => c.SwaggerDoc("v1"
                , new OpenApiInfo {Title = "Rai Tracking API", Version = "v1"}));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ICorsSetting corsOptions)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.ConfigureExceptionHandler(env);
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseAuthentication();
            RegisterMiddleware(app);
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rai tracking API"));
            app.UseCors(corsOptions.PolicyName);
        }

        private static void RegisterMiddleware(IApplicationBuilder app)
        {
            app.UseMiddleware<UserProviderMiddleware>();
            app.UseMiddleware<AgentProviderMiddleware>();
        }

        public void ConfigureContainer(ContainerBuilder builder)
            => builder.RegisterApplicationComponents();
    }
}