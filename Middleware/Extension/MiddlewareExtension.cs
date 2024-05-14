using Middleware.Middlewares;

namespace Middleware.Extension
{
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseControlMiddleware(this IApplicationBuilder builder) 
        {
            return builder.UseMiddleware<ControlMiddleware>();
        }
    }
}
