var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/stock", StockWithDefaultValue);

//app.Run();
//string StockWithDefaultValue(int id = 0) => $"Received {id}";
app.MapGet("/links", (LinkGenerator links) =>
{
    string link = links.GetPathByName("products");
    return $"View the product at {link}";
});