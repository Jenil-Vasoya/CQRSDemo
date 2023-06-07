using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CQRSDemo.Auth
{
    public class MyTrackingActionFilter : ActionFilterAttribute
    {   
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            Trace.TraceInformation(" Entering {0}", filterContext.RouteData);
            string controllerName = filterContext.RouteData.Values["controller"].ToString();
            string actionName = filterContext.RouteData.Values["action"].ToString();

            if(actionName == "GetUserData")
            {
                if (!filterContext.ActionArguments.TryGetValue("UserId", out var _))
                {
                    var errorResult = new BadRequestObjectResult("UserId is required.");
                    filterContext.Result = errorResult;
                }
            }
            
        }
    }
}
