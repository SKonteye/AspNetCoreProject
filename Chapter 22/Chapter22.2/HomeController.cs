using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chapter22._2
{
    public class HomeController: ControllerBase
    {
        //override missing in the method
        public void OnActionExecuting(
            ActionExecutingContext Context)
        {

        }
        //override missing in the method
        public void OnActionExecuted( ActionExecutedContext Context) { }
    }
}
