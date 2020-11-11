using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PlatfozaTestTask.API.Providers;

namespace PlatfozaTestTask.API.Middlewares
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate _next;

        public SessionMiddleware(RequestDelegate next) => 
            _next = next;

        public async Task Invoke(HttpContext context, SessionProvider sessionProvider)
        {
            sessionProvider.OpenSession();
            await _next(context);
            sessionProvider.CloseSession();
        }
    }
}