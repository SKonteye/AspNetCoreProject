using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IMessageSender, EmailSender>();
builder.Services.TryAddScoped<IMessageSender, EmailSender>();
var app = builder.Build();

app.MapGet("/register/{username}", () => "Hello World!");

app.Run();
public interface IMessageSender
{
}
public class EmailSender: IMessageSender
{
}