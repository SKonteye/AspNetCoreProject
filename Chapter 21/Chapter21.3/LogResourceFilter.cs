using Microsoft.AspNetCore.Mvc.Filters;

namespace Chapter21._3
{
    public class LogResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("Executing Resource!");
        }
    }
}