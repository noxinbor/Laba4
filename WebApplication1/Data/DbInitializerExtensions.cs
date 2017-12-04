using Microsoft.AspNetCore.Builder;
using WebApplication1.Data;

namespace WebApplication1.Data
{
    public static class DbInitializerExtensions
    {
        public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DbInitializerMiddleware>();
        }

    }
}