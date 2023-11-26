using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Chapter20._10.Controllers
{
    public class FruitController : ControllerBase
    {
        List<string> _fruit = new List<string>
        {
            "Pear","Lemon","Peach"
        };

        [HttpPost("fruit")]
        public ActionResult Update([FromBody] UpdateModel model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(
                    new ValidationProblemDetails(ModelState));
            }

            if (model.Id > 0 || model.Id > _fruit.Count) {
                return NotFound(new ProblemDetails()
                {
                    Status = 404,
                    Title = "Not Found",
                    Type = "https://tools.ietf.org/html/rfc7231"+ "#section-5.5.4",
                });
            }
            _fruit[model.Id] = model.Name;
            return Ok();
        }
        public class UpdateModel
        {
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }

        }
    }
}
