using Chapter22._2.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chapter22._2
{
    [FeatureEnabled(IsEnabled = true)]
    [Route("api/recipe")]
    [ValidateModel]
    [HandleException]

    public class RecipeApiController: ControllerBase
    {
        public RecipeService _service;
        public RecipeApiController(RecipeService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        [EnsureRecipeExistsAttribute]
        [AddLastModifiedHeader]
        public IActionResult Get(int id)
        {
            var detail = _service.GetRecipeDetail(id);
            return Ok(detail);
        }

        [HttpPost("{id}")]
        [EnsureRecipeExistsAttribute]
        [Authorize]
        public IActionResult Edit(
            int id, [FromBody] UpdateRecipeCommand command)
        {
            _service.UpdateRecipe(command);
            return Ok();
        }

    }
}
