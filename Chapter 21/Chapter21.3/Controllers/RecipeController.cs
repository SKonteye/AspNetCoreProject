using Microsoft.AspNetCore.Mvc;

namespace Chapter21._3.Controllers
{
    [LogResourceFilter]
    public class RecipeController : ControllerBase
    {
        //[LogResourceFilter]
        public IActionResult Index()
        {
            return Ok();
        }
        public IActionResult View()
        {
            return Ok();
        }
    }
}
