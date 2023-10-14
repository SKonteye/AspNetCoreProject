using Chapter9_11_service_lifetimes;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<DataContext>();
//builder.Services.AddTransient<Repository>();
//builder.Services.AddScoped<DataContext>();
////builder.Services.AddScoped<Repository>();
//builder.Services.AddSingleton<DataContext>();
builder.Host.UseDefaultServiceProvider(o =>
{
    o.ValidateScopes = true;
    o.ValidateOnBuild = false;
}

);

builder.Services.AddScoped<Repository>();
builder.Services.AddSingleton<Repository>();
var app = builder.Build();

//app.MapGet("/transient", RowCounts);
//app.MapGet("/scoped", RowCounts);
app.MapGet("/singleton", RowCounts);

app.Run();

static string RowCounts(
    DataContext db,
    Repository repository)
{
    int dbCount = db.RowCount;
    int repositoryCount = repository.RowCount;

    return $"DataContext: {dbCount}, Repository: {repositoryCount}";
}