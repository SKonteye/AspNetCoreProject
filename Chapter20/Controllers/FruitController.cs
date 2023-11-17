using Microsoft.AspNetCore.Mvc;

namespace Chapter20.Controllers
{
    public class FruitController : ControllerBase
    {
        List<string> _fruit = new List<string>
        {
            "Pear",
            "Lemon",
            "Peach"
        };

        [HttpGet("fruit")]
        public IEnumerable<string> Index()
        {
            return _fruit;
        }

        [HttpGet("fruit/{id}")]
        public ActionResult<string> View(int id) {
            if (id >= 0 && id < _fruit.Count) {
                return _fruit[id];
            }
            return NotFound();
        }
    }
}
