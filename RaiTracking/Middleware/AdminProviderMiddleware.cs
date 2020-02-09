using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RaiTracking.Middleware
{
    public class AdminProviderMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminProviderMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
        }
    }
}
