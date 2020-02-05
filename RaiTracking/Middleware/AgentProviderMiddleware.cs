using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace RaiTracking.Middleware
{
    public class AgentProviderMiddleware
    {
        private readonly RequestDelegate _next;

        public AgentProviderMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);
        }
    }
}
