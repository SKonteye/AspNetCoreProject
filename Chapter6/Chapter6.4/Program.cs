var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RouteOptions>(o =>
{
    o.LowercaseUrls = true;
    o.AppendTrailingSlash = true;
    o.LowercaseQueryStrings = true;
});

var app = builder.Build();

app.MapGet("/HealthCheck", () => Results.Ok()).WithName("healthcheck");
app.MapGet("/{name}", (string name) => name).WithName("product");

app.MapGet("/", (LinkGenerator links) =>
new[]
{
    links.GetPathByName("healthcheck",
    options: new LinkOptions{
        AppendTrailingSlash = false,
        LowercaseUrls = false
    }),
    links.GetPathByName("product",
    new { Name = "Big-Widget", Q="Test"})
});
app.Run();
