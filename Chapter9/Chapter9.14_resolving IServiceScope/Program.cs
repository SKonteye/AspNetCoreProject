var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<DataContext>();
var app = builder.Build();

await using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext =
        scope.ServiceProvider.GetRequiredService<DataContext>();
    Console.WriteLine($"Retrieved scope: {dbContext.RowCount}");
}

app.Run();
