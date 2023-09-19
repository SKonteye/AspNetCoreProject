var builder = WebApplication.CreateBuilder(args);

IHostEnvironment env = builder.Environment;

builder.Configuration.Sources.Clear();
builder.Configuration
    .AddJsonFile(
    "appsettings.json",
    optional: false)
    .AddJsonFile(
    $"appsettings.{env}.json",
    optional: true);
if (env.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
