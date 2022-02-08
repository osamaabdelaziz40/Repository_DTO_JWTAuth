using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRJ.API.Filters
{
    //Logging user activities to the system
    public class LogFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var requestData = string.Empty;
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];

            var requestUrl = "/api/" + $"{controllerName}/{actionName}";

            if (!string.IsNullOrEmpty(context.HttpContext.Request.QueryString.Value))
            {
                requestData = context.HttpContext.Request.QueryString.Value;
            }
            else
            {
                var rawData = context.ActionArguments.ToList();
                requestData = JsonConvert.SerializeObject(rawData);
            }
            
        }
    }
}
