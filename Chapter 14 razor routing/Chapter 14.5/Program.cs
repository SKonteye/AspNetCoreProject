using Chapter_14._5;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages()
//    .AddRazorPagesOptions(opts =>
//    {
//        opts.Conventions.Add(
//            new PageRouteTransformerConvention(
//                new KebabCaseParameterTransformer())
//            );
//        opts.Conventions.AddPageRoute(
//            "Search/Products/StartSearch", "/search-products");
//    }
//);

builder.Services.AddRazorPages()
    .AddRazorPagesOptions(opts =>
    {
        opts.Conventions.Add( new PrefixingPageRouteModelConvention());
    }
);

builder.Services.Configure<RouteOptions>(o =>
{
    o.LowercaseUrls = true;
    o.LowercaseQueryStrings = true;
    o.AppendTrailingSlash = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
