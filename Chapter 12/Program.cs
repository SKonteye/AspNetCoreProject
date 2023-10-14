using Chapter12;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite(connString));

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Helloo");

//app.UseSwagger();
//app.UseSwaggerUI();
app.Run();

public class CreateRecipeCommand
{
    public string Name { get; set; }
    public int TimeToCookHrs { get; set; }
    public int TimeToCookMins { get; set; }
    public string Method { get; set; }
    public bool IsVegetarian { get; set; }
    public IEnumerable<Ingredient> Ingredients { get; set; }
    public bool IsVegan { get; set; }
}

public class Recipe
{
    public int RecipeId { get; set; }
    public required string Name { get; set; }
    public TimeSpan TimeToCook { get; set; }
    public bool IsDeleted { get; set; }
    public required string Method { get; set; }
    public bool IsVegetarian { get; set; }
    public bool IsVegan { get; set; }
    public required ICollection<Ingredient> Ingredients { get; set; }
}

public class Ingredient
{
    public int IngredientId { get; set; }
    public int RecipeId { get; set; }
    public required string Name { get; set; }
    public decimal Quantity { get; set; }
    public required string Unit { get; set; }
}
public class RecipeDetailViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Method { get; set; }
    public object Ingredients { get; set; }

    internal class item
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
    }
}

public class RecipeSummaryViewModel
{
    public int Id { get; set; }
    public string TimeToCook { get; set; }
    public string Name { get; set; }
    public string Method { get; internal set; }
    public object Ingredients { get; internal set; }

}
public class UpdateRecipeCommand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TimeToCookHrs { get; set; }
    public int TimeToCookMins { get; set; }
    public string Method { get; set; }
    public bool IsVegetarian { get; set; }
    public IEnumerable<Ingredient> Ingredients { get; set; }
    public bool IsVegan { get; set; }
}