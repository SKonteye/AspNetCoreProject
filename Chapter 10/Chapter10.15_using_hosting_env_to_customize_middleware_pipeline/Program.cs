var builder = WebApplication.CreateBuilder(args);
builder.Services.AddProblemDetails();

var app = builder.Build();

if(!builder.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}
app.MapGet("/", () => "Hello World!");

app.Run();
