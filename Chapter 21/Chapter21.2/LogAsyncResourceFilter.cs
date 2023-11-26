using Microsoft.AspNetCore.Mvc.Filters;

namespace Chapter21._2
{
    public class LogAsyncResourceFilter : Attribute, IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            Console.WriteLine("Executing async!");
            ResourceExecutedContext executedContext = await next();
            Console.WriteLine("Executed async!");
        }
    }
}
