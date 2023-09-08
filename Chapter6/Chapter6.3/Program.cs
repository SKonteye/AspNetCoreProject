var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/test", () => "Hello World!")
    .WithName("hello");
app.MapGet("/redirect-me",
    () => Results.RedirectToRoute("hello"));
app.Run();
