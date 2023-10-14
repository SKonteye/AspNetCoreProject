var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/display-settings", (IConfiguration config) =>
{
    string title = config["AppDisplaySettings:Title"];
    bool showCopyright = bool.Parse(
        config["AppDisplaySettings:ShowCopyright"]);
    return new { title, showCopyright };
});

app.Run();
