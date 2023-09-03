using Microsoft.AspNetCore.Http;
using System.Collections.Concurrent;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var _fruit = new ConcurrentDictionary<string, Fruit>();
RouteGroupBuilder fruitApi = app.MapGroup("/fruit");
fruitApi.MapGet("/", ()=>_fruit);
RouteGroupBuilder fruitApiWithValidation = fruitApi.MapGroup("/")
    .AddEndpointFilterFactory(ValidationHelper.ValidateIdFactory);
fruitApiWithValidation.MapGet("/{id}", (string id) =>
_fruit.TryGetValue(id, out var fruit)
? TypedResults.Ok(fruit)
: Results.Problem(statusCode: 400));

fruitApiWithValidation.MapPost("/{id}", (Fruit fruit, string id) =>
_fruit.TryAdd(id, fruit)
? TypedResults.Created($"/fruit/{id}", fruit)
: Results.ValidationProblem(new Dictionary<string, string[]>
{

    { "id", new[] { "A fruit with this id already exists" } }
}));

fruitApiWithValidation.MapPut("/{id}", (string id, Fruit fruit) => {
    _fruit[id] = fruit;
    return Results.NoContent();
});

fruitApiWithValidation.MapDelete("/fruit/{id}", (string id) =>
{
    _fruit.TryRemove(id, out _);
});

app.Run();
class ValidationHelper
{
    internal static EndpointFilterDelegate ValidateIdFactory(
        EndpointFilterFactoryContext context,
        EndpointFilterDelegate next)
    {
        ParameterInfo[] parameters =
            context.MethodInfo.GetParameters();
        int? idposition =null;
        for (int i = 0; i < parameters.Length; i++) {
            if (parameters[i].Name == "id" &&
                parameters[i].ParameterType==typeof(string))
            {
                idposition = i;
                break;
            }
        }
        if (!idposition.HasValue)
        {
            return next;
        }
        return async (invocationContext) =>
        {
            var id = invocationContext.GetArgument<string>(idposition.Value);
            if(string.IsNullOrEmpty(id) || !id.StartsWith('f'))
            {
                return Results.ValidationProblem(
                    new Dictionary<string, string[]>
                    {
                        {"id", new [] { "Id must start with 'f'"} }
                    });
            }
            return await next(invocationContext);

        };

    }
}
record Fruit(string Name, int Stock);
