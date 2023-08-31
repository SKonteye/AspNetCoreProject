using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var _fruit = new ConcurrentDictionary<string, Fruit>();
app.MapGet("/fruit/{id}", (string id) =>
_fruit.TryGetValue(id, out var fruit)
? TypedResults.Ok(fruit)
:Results.Problem(statusCode: 404))
.AddEndpointFilter<IdValidationFilter>();

app.Run();
record Fruit (string Name, int Stock);
class IdValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var id = context.GetArgument<string>(0);
        if (string.IsNullOrEmpty(id) || !id.StartsWith('f'))
        {
            return Results.ValidationProblem(
                new Dictionary<string, string[]>
                {
                    {"id", new string[] {"Invalid format. Id must start with 'f'"} }
                });
        }
        return await next(context);
    }
}