using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Configuring ExceptionHandler
//builder.Services.AddProblemDetails();
//WebApplication app = builder.Build();
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler();
//}
//app.MapGet("/", void () => throw new Exception());
//app.Run();
//*****************************************************************************************************************//
//Using StatusCodeMiddleware
//builder.Services.AddProblemDetails();
//WebApplication app = builder.Build();
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler();
//}
//app.UseStatusCodePages();
//app.MapGet("/", ()=> Results.NotFound());
//app.Run();
//*****************************************************************************************************************//
//basic validation in minimal api
//WebApplication app = builder.Build();
//var _fruit = new ConcurrentDictionary<string, Fruit>();
//app.MapGet("/fruit{id}", (string id) =>
//{
//    if (string.IsNullOrEmpty(id) || !id.StartsWith('f'))

//    {
//        return Results.ValidationProblem(new Dictionary<string, string[]>
//        {
//            {"id", new[] {"Invalid format. Id must start with 'f'"} }
//        });
//    }
//    return _fruit.TryGetValue(id, out var fruit)
//        ? TypedResults.Ok(fruit)
//        : Results.Problem(statusCode: 404);
//});
//app.Run();
//record Fruit(string Name, int Stock);
//*****************************************************************************************************************//
//adding multiple filters to the endpoint filter pipeline
var _fruit = new ConcurrentDictionary<string, Fruit>();
app.MapGet("/fruit/{id}", (string id) =>
_fruit.TryGetValue(id, out var fruit)
? TypedResults.Ok(fruit)
: Results.Problem(statusCode: 404))
    .AddEndpointFilter(ValidationHelper.ValidateId)
    .AddEndpointFilter(async (context, next) =>
{
app.Logger.LogInformation("Executing filter...");
object? result = await next(context);
app.Logger.LogInformation($"Handler result:{result}");
return result;
});
app.Run();
record Fruit(string Name, int Stock);
class ValidationHelper
{
    internal static async ValueTask<object?> ValidateId(
        EndpointFilterInvocationContext context,
        EndpointFilterDelegate next)
    {
        var id = context.GetArgument<string>(0);
        if (string.IsNullOrEmpty(id) || !id.StartsWith('f'))
        {
            return Results.ValidationProblem(
                new Dictionary<string, string[]>
                {
                    {"id", new[] {"Invalid format. Id must start with 'f'"} }
                });
        }

        return await next(context);
    }
}

