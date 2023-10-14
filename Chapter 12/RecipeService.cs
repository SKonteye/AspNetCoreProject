using Microsoft.EntityFrameworkCore;

namespace Chapter12
{
    public class RecipeService
    {
        readonly AppDbContext _context;
        public async Task<int> CreateRecipe(CreateRecipeCommand cmd)
        {
            var recipe = new Recipe
            {
                Name = cmd.Name,
                TimeToCook = new TimeSpan(
                    cmd.TimeToCookHrs, cmd.TimeToCookMins, 0
                ),
                Method = cmd.Method,
                IsVegetarian = cmd.IsVegetarian,
                IsVegan = cmd.IsVegan,
                Ingredients = cmd.Ingredients.Select(i =>
                new Ingredient
                {
                    Name = i.Name,
                    Quantity = i.Quantity,
                    Unit = i.Unit,
                }).ToList()
            };
            _context.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe.RecipeId;
        }

        public async Task<ICollection<RecipeSummaryViewModel>> GetRecipes()
        {
            return await _context.Recipes
                .Where(r => !r.IsDeleted)
                .Select(r => new RecipeSummaryViewModel
                {
                    Id = r.RecipeId,
                    Name = r.Name,
                    TimeToCook = $"{r.TimeToCook}mins"
                }).ToListAsync();
        }
        public async Task<RecipeDetailViewModel> GetRecipeDetail(int id)
        {
            return await _context.Recipes
                .Where(x => x.RecipeId == id)
                .Select(x => new RecipeDetailViewModel
                {
                    Id = x.RecipeId,
                    Name = x.Name,
                    Method = x.Method,
                    Ingredients = x.Ingredients
                    .Select(item => new RecipeDetailViewModel.item
                    {
                        Name = item.Name,
                        Quantity = $"{item.Quantity} {item.Unit}"
                    })
                }).SingleOrDefaultAsync();
        }

        public async Task UpdateRecipe(UpdateRecipeCommand cmd)
        {
            var recipe = await _context.Recipes.FindAsync(cmd.Id);
            if (recipe is null)
            {
                throw new Exception("Unable to find the recipe");
            }
            UpdateRecipe(recipe, cmd);
            await _context.SaveChangesAsync();
        }
        static void UpdateRecipe(Recipe recipe, UpdateRecipeCommand cmd)
        {
            recipe.Name = cmd.Name;
            recipe.TimeToCook = new TimeSpan(cmd.TimeToCookHrs, cmd.TimeToCookMins, 0);
            recipe.Method = cmd.Method;
            recipe.IsVegetarian = cmd.IsVegetarian;
            recipe.IsVegan = cmd.IsVegan;
        }

        public async Task DeleteRecipe(int recipeId)
        {
            var recipe = await _context.Recipes.FindAsync(recipeId);
            if (recipe is null)
            {
                throw new Exception("Unable to find the recipe");
            }
            recipe.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }

}
