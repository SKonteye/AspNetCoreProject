using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MapSettings>(
    builder.Configuration.GetSection("MapSettings"));
builder.Services.AddSingleton(provider =>
    provider.GetRequiredService<IOptions<MapSettings>>().Value);
var app = builder.Build();

app.MapGet("/", (MapSettings mapSettings) => mapSettings);

app.Run();
