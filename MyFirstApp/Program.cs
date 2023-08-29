using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Collections.Concurrent;
using System.Net.Mime;

var builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();
app.MapGet("/", ()=> "Hello world");
app.Run();