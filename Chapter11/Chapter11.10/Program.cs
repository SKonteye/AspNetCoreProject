using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var _fruit = new ConcurrentDictionary<string, Fruit>();
app.MapGet("/fruit/{id}",
    [EndpointName("GetFruit")]
    [EndpointSummary("Fetches a fruit by id, or returns 404" +
        " id no fruit with the ID exists")]
    [ProducesResponseType(typeof(Fruit), 200)]
    [ProducesResponseType(typeof(HttpValidationProblemDetails), 404,
    "application/problem+json")]
    (string id) =>
    _fruit.TryGetValue(id, out var fruit)
    ? TypedResults.Ok(fruit)
    : Results.Problem(statusCode: 400))
    .WithOpenApi(o=>
    {
        o.Parameters[0].Description = "The id of the fruit to fetch";
        return o;
    });

app.Run();
record Fruit(string Name, int Stock);
