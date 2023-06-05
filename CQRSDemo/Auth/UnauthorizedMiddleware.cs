using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Text.Json;

namespace CQRSDemo.Auth
{
    public class UnauthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public UnauthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    try
        //    {
        //        await _next(context);
        //    }
        //    catch (UnauthorizedAccessException)
        //    {
        //        var response = new
        //        {
        //            error = "Unauthorized access"
        //        };

        //        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        //        context.Response.ContentType = "application/json";
        //        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        //    }
        //}

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
            {
                context.Response.ContentType = "application/json";

                var response = new
                {
                    error = "You are not Authorized Person"
                };

                var json = JsonSerializer.Serialize(response.error);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
