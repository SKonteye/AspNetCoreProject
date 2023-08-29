using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();
//app.MapGet("/teapot", (HttpResponse response) =>
//{
//    response.StatusCode = 418;
//    response.ContentType = MediaTypeNames.Text.Plain;
//    return response.WriteAsync("I'm a teapot!");
//});
//app.Run();
//*****************************************************************************************************************//

//Results.problem and Results.ValidationProblem

var _fruit = new ConcurrentDictionary<string, Fruit>();
app.MapGet("/fruit", () =>
_fruit);

app.MapGet("/fruit/{id}", (string id) =>
_fruit.TryGetValue(id, out var fruit)
? TypedResults.Ok(fruit)
: Results.Problem(statusCode: 404));

app.MapPost("/fruit/{id}", (string id, Fruit fruit) =>
_fruit.TryAdd(id, fruit)
? TypedResults.Created($"/fruit/{id}", fruit)
: Results.ValidationProblem(new Dictionary<string, string[]>
{
    {"id", new[] {"A fruit with this id already exists"} }
}));
app.Run();
record Fruit(string Name, int Stock);