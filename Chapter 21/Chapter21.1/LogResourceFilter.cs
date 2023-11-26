using Microsoft.AspNetCore.Mvc.Filters;

namespace Chapter21._1
{
    public class LogResourceFilter: Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("Executing!");
        }
    }
}
