using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chapter20._11.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        List<string> _fruit = new List<string>
        {
            "Pear", "Lemon", "Peach"
        };

        // POST api/<FruitController>
        [HttpPost("fruit")]
        public ActionResult Update(UpdateModel model)
        {
            if(model.Id < 0 || model.Id > _fruit.Count)
            {
                return NotFound();
            }
            _fruit[model.Id] = model.Name;
            return Ok();
        }

    }
    public class UpdateModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
