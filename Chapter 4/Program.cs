
//Middleware pipeline for a minimal APIs application
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.MapGet("/", () => "Hello World");
app.UseDeveloperExceptionPage();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}
app.MapGet("/error", () => "Sorry, an error occured");
app.Run();
