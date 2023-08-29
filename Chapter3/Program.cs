
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();
builder.Services.AddHttpLogging(opts =>
opts.LoggingFields = HttpLoggingFields.RequestProperties);
builder.Logging.AddFilter("Microsoft.AspNetCore.HttpLogging", LogLevel.Information);
if (app.Environment.IsDevelopment())
{
    app.UseHttpLogging();
}
app.MapGet("/", () => "Hello World!");
RouteHandlerBuilder routeHandlerBuilder = app.MapGet("/person", () => new Person("Andrew", "Lock"));
app.UseWelcomePage();
app.UseStaticFiles();
app.Run();
public record Person(string FirstName, string LastName);
