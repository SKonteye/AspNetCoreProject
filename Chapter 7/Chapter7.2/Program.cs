var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/product/{id}", (ProductId id) => $"Received {id}");
app.Run();
readonly record struct ProductId(int Id)
{
    public static bool TryParse(string? s, out ProductId result)
    {
        if (s is not null
          && s.StartsWith("p")
          && int.TryParse(
              s.AsSpan().Slice(1),
              out int id))
        {
            result = new ProductId(id);
            return true;
        }

        result = default;
        return false;
    }
}
