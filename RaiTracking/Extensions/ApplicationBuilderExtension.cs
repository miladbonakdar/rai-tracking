using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace RaiTracking.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseApplicationStaticFiles(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cachePeriod = env.IsDevelopment() ? "600" : "604800"; //6 min and 7 days
            var path = Path.Combine(Startup.ApplicationPath, @"Statics");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(path),
                RequestPath = new PathString("/statics"),
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cachePeriod}");
                }
            });
        }
    }
}