using System.Web.Mvc;

namespace MvcApplication.App_Start
{
    public class MyActionFilterAttribute : ActionFilterAttribute { 
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.AddHeader("X-TEST-ID", System.Guid.NewGuid().ToString());
        }      
    }
}