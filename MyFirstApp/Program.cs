using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections.Concurrent;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();
//builder.Services.AddHttpLogging(opts =>
//opts.LoggingFields = HttpLoggingFields.RequestProperties);
//builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);

//WebApplication app = builder.Build();
//if (app.Environment.IsDevelopment())
//{
//    app.UseHttpLogging();
//}
//app.MapGet("/", () => "Hello World!");
//RouteHandlerBuilder routeHandlerBuilder = app.MapGet("/person", () => new Person("Andrew", "Lock"));
//app.UseWelcomePage();
//app.UseStaticFiles();
//app.Run();
//public record Person(string FirstName , string LastName);

//**********************************//
//Middleware pipeline for a minimal APIs application
//WebApplication app = builder.Build();
//app.UseDeveloperExceptionPage();
//app.UseStaticFiles();
//app.UseRouting();
//app.MapGet("/", () => "Hello World");
//app.Run();
//WebApplication app = builder.Build();
//app.UseDeveloperExceptionPage();
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/error");
//}
//app.MapGet("/error", () => "Sorry, an error occured");
//app.Run();
//******************************************************************************************************************//
//* Json API with minimal API*//
//WebApplication app = builder.Build();
//var people = new List<Person>
//{
//    new Person("Moussa", "Diop"),
//    new Person("Abdou", "Fall"),
//    new Person("Fatou", "Toure"),
//    new Person("Awa", "Kasse")
//};

//app.MapGet("/person/{name}", (string name) =>
//people.Where(p => p.firstName.StartsWith(name)));
//app.Run();
//public record Person (string firstName, string lastName);
//*****************************************************************************************************************//

//Creating route handlers for a simple CRUD API//
//WebApplication app = builder.Build();
//app.MapGet("/fruit", () => Fruit.All);
//var getFruit = (string id) => Fruit.All[id];
//app.MapGet("/fruit/{id}", getFruit);
//var fruit = new Fruit("Mangue", 10);
//app.MapPost("/fruit/{id}", Handlers.AddFruit);
//Handlers handlers = new Handlers();
//app.MapPut("/fruit/{id}", handlers.ReplaceFruit);
//app.MapDelete("/fruit/{id}", DeleteFruit);
//app.Run();
//void DeleteFruit(string id)
//{
//    Fruit.All.Remove(id);
//}
//record Fruit (string Name, int Stock)
//{
//    public static readonly Dictionary<string, Fruit> All = new();
//};
//class Handlers
//{
//    public void ReplaceFruit (string id, Fruit fruit)
//    {
//        Fruit.All[id] = fruit;
//    }
//    public static void AddFruit(string id, Fruit fruit)
//    {
//        Fruit.All.Add(id,fruit);
//    }
//}
//*****************************************************************************************************************//
//WebApplication app = builder.Build();

//var _fruit = new ConcurrentDictionary<string, Fruit>();
//app.MapGet("/fruit", ()=> _fruit);
//app.MapGet("/fruit/{id}", (string id) =>
//_fruit.TryGetValue(id, out var fruit)
//? TypedResults.Ok(fruit)
//: Results.NotFound());
//app.MapPost("/fruit/{id}", (string id, Fruit fruit) =>
//_fruit.TryAdd(id, fruit)
//? TypedResults.Created($"/fruit/{id}", fruit)
//: Results.BadRequest(new
//{
//    id = " A fruit with this id already exists"
//}));
//app.MapPut("/fruit/{id}", (string id, Fruit fruit) =>
//{
//    _fruit[id] = fruit;
//    return Results.NoContent();
//});
//app.MapDelete("/fruit/{id}", (string id) =>
//{
//    _fruit.TryRemove(id, out _);
//    return Results.NoContent();
//});
//app.Run();
//record Fruit (string Name, int Stock);
//*****************************************************************************************************************//

//WebApplication app = builder.Build();
//app.MapGet("/teapot", (HttpResponse response) =>
//{
//    response.StatusCode = 418;
//    response.ContentType = MediaTypeNames.Text.Plain;
//    return response.WriteAsync("I'm a teapot!");
//});
//app.Run();
//*****************************************************************************************************************//
//Results.problem and Results.ValidationProblem
//WebApplication app = builder.Build();

//var _fruit = new ConcurrentDictionary<string, Fruit>();
//app.MapGet("/fruit", ()=> 
//_fruit);

//app.MapGet("/fruit/{id}", (string id) =>
//_fruit.TryGetValue(id, out var fruit)
//? TypedResults.Ok(fruit)
//: Results.Problem(statusCode: 404));

//app.MapPost("/fruit/{id}", (string id, Fruit fruit) =>
//_fruit.TryAdd(id, fruit)
//? TypedResults.Created($"/fruit/{id}", fruit)
//: Results.ValidationProblem(new Dictionary<string, string[]>
//{
//    {"id", new[] {"A fruit with this id already exists"} }
//}));
//app.Run();
//record Fruit (string Name, int Stock);
//*****************************************************************************************************************//
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
