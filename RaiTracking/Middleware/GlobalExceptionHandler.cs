using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Serilog;
using SharedKernel;
using SharedKernel.Exceptions;

namespace RaiTracking.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        //https://code-maze.com/global-error-handling-aspnetcore/
        public static void ConfigureExceptionHandler(this IApplicationBuilder app,
            IWebHostEnvironment env)
        {
            async Task Handler(HttpContext context)
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var logger = Log.Logger;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    switch (contextFeature.Error)
                    {
                        case BadRequestException _:
                            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                            logger.Error($"Bad Request : {contextFeature.Error}");
                            break;
                        case NotFoundException _:
                            context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                            logger.Warning($"Not Found : {contextFeature.Error}");
                            break;
                        case ForbiddenException _:
                            context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
                            logger.Error($"Forbidden : {contextFeature.Error}");
                            break;
                        case UnauthorizedException _:
                            logger.Error($"Unauthorized : {contextFeature.Error}");
                            context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                            break;
                        case ApplicationException _:
                            logger.Error($"App Invalid Operation : {contextFeature.Error}");
                            context.Response.StatusCode = (int) HttpStatusCode.Conflict;
                            break;
                        default:
                            logger.Fatal($"FATAL ERROR: {contextFeature.Error}");
                            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                            break;
                    }

                    var error = Result<string>.Create(contextFeature.Error.Message,
                        context.Response.StatusCode, false,
                        env.IsDevelopment() && context.Response.StatusCode == (int) HttpStatusCode.InternalServerError
                            ? contextFeature.Error.ToString()
                            : contextFeature.Error.Message);
                    await context.Response.WriteAsync(error.ToString());
                }
            }

            app.UseExceptionHandler(appError => { appError.Run(Handler); });
        }
    }
}