using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chapter22._2.Filters
{
    public class EnsureRecipeExistsFilter : IActionFilter
    {
        private readonly RecipeService _recipeService;
        public EnsureRecipeExistsFilter(RecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var recipeId = (int)context.ActionArguments["id"];
            if (!_recipeService.DoesRecipeExist(recipeId))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
    public class EnsureRecipeExistsAttribute: TypeFilterAttribute
    {
        public EnsureRecipeExistsAttribute() : base(typeof(EnsureRecipeExistsFilter)){ }
    }

}