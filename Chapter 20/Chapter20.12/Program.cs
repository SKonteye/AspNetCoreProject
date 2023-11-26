using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers()
//    .ConfigureApiBehaviorOptions(options =>
//    options.SuppressModelStateInvalidFilter = true);
builder.Services.AddControllers(options => {

    options.RespectBrowserAcceptHeader = true;
    options.OutputFormatters.RemoveType<StringOutputFormatter>();
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
