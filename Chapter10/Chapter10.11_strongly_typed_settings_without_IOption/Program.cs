var builder = WebApplication.CreateBuilder(args);

var settings = new MapSettings();
builder.Configuration.GetSection("MapSettings").Bind(settings);
builder.Services.AddSingleton(settings);
var app = builder.Build();

app.MapGet("/", (MapSettings mapSettings) => mapSettings);

app.Run();
