using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/category/{id}", ([AsParameters]SearchModel model) => $"Received {model}");

app.Run();

record struct SearchModel(
    int id,
    int page,
    [FromHeader(Name ="sort")] bool? sortAsc,
    [FromQuery(Name ="q")] string search);