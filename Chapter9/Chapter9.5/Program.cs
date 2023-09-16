var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<NetworkClient>();
builder.Services.AddSingleton<MessageFactory>();
builder.Services.AddScoped(
    provider =>
    new EmailServerSettings
    (
        Host: "smtp.server.com",
        Port: 25
        ));



var app = builder.Build();

app.MapGet("/register/{username}", RegisterUser);

string RegisterUser(string username)
{
    return $"Email sent to {username}";
}

app.Run();
public interface IEmailSender
{
}
public class EmailSender:IEmailSender
{
}
public class EmailServerSettings
{
    private string host;
    private int port;

    public EmailServerSettings(string Host, int Port)
    {
        host = Host;
        port = Port;
    }
}
public class NetworkClient
{
}
public class MessageFactory
{
}
