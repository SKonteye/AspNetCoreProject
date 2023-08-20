using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);
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
//**********************************//
//* Json API with minimal API*//
WebApplication app = builder.Build();
var people = new List<Person>
{
    new Person("Moussa", "Diop"),
    new Person("Abdou", "Fall"),
    new Person("Fatou", "Toure"),
    new Person("Awa", "Kasse")
};

app.MapGet("/person/{name}", (string name) =>
people.Where(p => p.firstName.StartsWith(name)));
app.Run();
public record Person (string firstName, string lastName);