using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chapter22._2.Filters
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var error = new ProblemDetails
            {
                Title = "An error occured",
                Detail = context.Exception.Message,
                Status = 500,
                Type = "https://httpwg.org/specs/rfc9110.html#status.500"
            };

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500,
            };
            context.ExceptionHandled = true;
        }
    }
}