using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chapter22._2.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}