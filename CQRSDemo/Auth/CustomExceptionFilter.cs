using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CQRSDemo.Auth
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        

        public void OnException(ExceptionContext context)
        {
            
            // Create a custom error response
            var errorResponse = new ProblemDetails
            {
                Status = 500,
                Title = "Internal Server Error",
                Detail = "Something went wrong! Internal Server Error."
            };

            // Set the response content
            context.Result = new ObjectResult(errorResponse)
            {
                StatusCode = 500,
                ContentTypes = { "application/problem+json" }
            };

            // Prevent further exception handling
            context.ExceptionHandled = true;
        }
    }
}
