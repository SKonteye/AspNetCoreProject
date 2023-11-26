using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Chapter22._1
{
    public class RecipeApiController
    {
        private readonly bool IsEnabled = true;
        public RecipeService _service;

        public object Response { get; private set; }

        public RecipeApiController(RecipeService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!IsEnabled)
            {
                return BadRequest();
            }
            try
            {
                if (!_service.DoesRecipeExist(id))
                {
                    return NotFound();
                }
                var detail = _service.GetRecipeDetail(id);
                Response.GetTypedHeaders().LastModified = detail.LastModified;
                return Ok(detail);
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        [HttpPost("{id}")]
        public IActionResult Edit(int id, [FromBody] UpdateRecipeCommand command)
        {
            if (!IsEnabled)
            {
                return BadRequest();
            }
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_service.DoesRecipeExist(id))
                {
                    return NotFound();
                }
                _service.UpdateRecipe(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        public static IActionResult GetErrorResponse(Exception ex)
        {
            var error = new ProblemDetails
            {
                Title = "An error occured",
                Detail = context.Exception.Message,
                Status = 500,
                Type = "https://httpstatuses.com/500"

            };

            return new ObjectResult(error)
            {
                StatusCode = 500
            };
        }

    }
}
}
