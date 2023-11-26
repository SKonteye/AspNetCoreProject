using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chapter22._2
{
    public class PageEnsureRecipeExistsAttribute : Attribute, IPageFilter
    {
        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            var service = context.HttpContext.RequestServices.GetService<RecipeService>();
            var recipeId = (int)context.HandlerArguments["id"];
            if (!service.DoesRecipeExist(recipeId)) {
                context.Result = new NotFoundResult();
            }
        }

        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            throw new NotImplementedException();
        }
    }
}
