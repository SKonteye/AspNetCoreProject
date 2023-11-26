using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chapter22._2.Filters
{
    public class EnsureRecipeExists : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var service = context.HttpContext.RequestServices
                .GetService<RecipeService>();
            var recipeId = (int)context.ActionArguments["id"];
            if (!service.DoesRecipeExist(recipeId))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}