using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace RaiTracking.Middleware
{
    public class IdentityProviderMiddleware
    {
        private readonly RequestDelegate _next;

        public IdentityProviderMiddleware(RequestDelegate next) => _next = next;

        public async Task Invoke(HttpContext httpContext, IIdentityProvider provider)
        {
            provider.SetUser(httpContext.User);
            await _next(httpContext);
        }
    }
}