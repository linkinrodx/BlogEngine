using Microsoft.AspNetCore.Builder;

namespace BlogEngine.API.Infraestructure
{
    public static class ExtensionsExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
