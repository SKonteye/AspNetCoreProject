using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chapter22._2.Filters
{
    public class AddLastModifiedHeaderAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult result
                && result.Value is RecipeDetailViewModel detail)
            {
                var viewModelDate = detail.LastModified;
                context.HttpContext.Response.GetTypedHeaders().LastModified = viewModelDate;
            }
        }
    }
}