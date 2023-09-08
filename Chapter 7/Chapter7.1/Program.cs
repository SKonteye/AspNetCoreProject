using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/products/{id}/paged",
    ([FromRoute] int id,
    [FromQuery] int page,
    [FromHeader (Name= "PageSize")] int pageSize)=>
    $"Received id  {id}, page {page}, pageSize {pageSize}");

app.Run();
