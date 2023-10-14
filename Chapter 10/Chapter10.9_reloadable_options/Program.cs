using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<AppDisplaySettings>(
    builder.Configuration.GetSection(nameof(AppDisplaySettings)));
var app = builder.Build();

app.MapGet("/display-settings", (IOptionsSnapshot<AppDisplaySettings> options) =>
{
    AppDisplaySettings settings = options.Value;
    return new
    {
        title = settings.Title,
        showCopyright = settings.ShowCopyright,
    };
});

app.Run();
