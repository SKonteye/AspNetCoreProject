var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/stock/{id?}", (int? id) => $"Received {id}");

app.MapGet("/stock2", (int? id) => $"Received {id}");

app.MapPost("/stock", (Product? product) => $"Received {product}");

app.Run();
record Product(int Id, string Name, int Stock);