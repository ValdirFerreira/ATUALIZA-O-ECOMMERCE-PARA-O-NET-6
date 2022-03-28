using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_ECommerce.Controllers
{
    public class LogActionFilter : ActionFilterAttribute
    {
        // Documento Log microsoft https://docs.microsoft.com/pt-br/aspnet/mvc/overview/older-versions-1/controllers-and-routing/understanding-action-filters-cs


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData, filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Log("OnResultExecuting", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Log("OnResultExecuted", filterContext.RouteData);
        }


        private void Log(string methodName, RouteData routeData, ActionExecutingContext filterContext = null)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);


            if (filterContext != null && filterContext.ActionArguments.Any())
            {
                var teste = JsonConvert.SerializeObject(filterContext.ActionArguments);
            }


            //  Debug.WriteLine(message, "Action Filter Log");
        }

    }
}
