using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace WebApplication1.Data
{
    public class DbInitializerMiddleware
    {
        private readonly RequestDelegate _next;
        public DbInitializerMiddleware(RequestDelegate next)
        {
            // инициализация базы данных 
            this._next = next;

        }
        //public async Task Invoke(HttpContext context) 
        //{ 
        // var token = context.Request.Query["token"]; 
        // if (string.IsNullOrWhiteSpace(token) || token != pattern) 
        // { 
        // context.Response.StatusCode = 403; 
        // await context.Response.WriteAsync("Token is invalid"); 
        // } 
        // else 
        // { 
        // await _next.Invoke(context); 
        // } 
        //} 

        public Task Invoke(HttpContext context, kindergartenContext dbContext)
        {
            if (!(context.Session.Keys.Contains("starting")))
            {
                DbInitializer.Initialize(dbContext);
                context.Session.SetString("starting", "Yes");
            }
            // Call the next delegate/middleware in the pipeline 
            return _next.Invoke(context);
        }
    }
}
