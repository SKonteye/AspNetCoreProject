var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

LinkGenerator links =
    app.Services.GetRequiredService<LinkGenerator>();
app.Run();
