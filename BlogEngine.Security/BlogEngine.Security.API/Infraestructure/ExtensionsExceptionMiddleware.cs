using Microsoft.AspNetCore.Builder;

namespace BlogEngine.Security.API.Infraestructure
{
    public static class ExtensionsExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
