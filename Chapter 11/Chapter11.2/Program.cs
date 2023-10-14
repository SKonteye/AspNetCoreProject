using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var _fruit = new ConcurrentDictionary<string, Fruit>();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/fruit/{id}", (string id) =>
    _fruit.TryGetValue(id, out var fruit)
    ? TypedResults.Ok(fruit)
    : Results.Problem(statusCode: 400))
    .WithTags("fruit")
    .WithName("fruitG")
    .Produces<Fruit>()
    .ProducesValidationProblem(404);
app.MapPost("/fruit/{id}", (string id, Fruit fruit) =>
     _fruit.TryAdd(id, fruit)
     ? TypedResults.Created($"/fruit/{id}", fruit)
     : Results.ValidationProblem(new Dictionary<string, string[]>
     {
         { "id", new[] { "A fruit with this id already exists"} }
     }))
    .WithTags("fruit")
    .WithName("fruitP")
    .Produces<Fruit>(201)
    .ProducesValidationProblem()
    ;

app.Run();
record Fruit(string Name, int Stock);