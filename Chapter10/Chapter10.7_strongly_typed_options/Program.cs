using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<MapSettings>(
    builder.Configuration.GetSection("MapSettings"));
builder.Services.Configure<AppDisplaySettings>(builder.Configuration.GetSection(nameof(AppDisplaySettings)));
var app = builder.Build();

app.MapGet("/display-settings", (IOptions<AppDisplaySettings> options) =>
    {
        AppDisplaySettings settings = options.Value;
        string title =settings.Title;
        bool showCopyright = settings.ShowCopyright;
        return new { title, showCopyright };
    });

app.Run();
