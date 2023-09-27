using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts=>
{
    var file = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, file));
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var _fruit = new ConcurrentDictionary<string, Fruit>();
var handler = new FruitHandler(fruit);
app.MapGet("/fruit/{id}", handler.GetFruit);

app.Run();
record Fruit(string Name, int Stock);

internal class FruitHandler
{
    private readonly ConcurrentDictionary<string, Fruit> _fruit;
    public FruitHandler(ConcurrentDictionary<string, Fruit> fruit)
    {
        _fruit = fruit;
    }

    /// <summary>
    /// Fetches a fruit by id, or returns 404 if it does not exist
    /// </summary>
    /// <param name="id" >The ID of the fruit to fetch</param>
    /// <response code="200">Returns the fruit if it exists</response>
    /// <response code="404">If the fruit doesn't exist</response>
    [ProducesResponseType(typeof(string), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails),
        404, "application/problem+json")]
    [Tags("fruit")]
    public IResult GetFruit(string id)
        => _fruit.TryGetValue(id, out var fruit)
        ? TypedResults.Ok(fruit)
        : Results.Problem(statusCode:404);
}