using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/products/search", ([FromQuery(Name = "id")] int[] ids) => $"Received { ids.Length} ids");

app.Run();
