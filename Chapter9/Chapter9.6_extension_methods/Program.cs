using Chapter9._6_extension_methods;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEmailSender();
var app = builder.Build();

app.MapGet("/register/{username}", RegisterUser);

string RegisterUser(string username)
{
    return $"Email sent to {username}";
}

app.Run();


public class EmailServerSettings
{
    private string host;
    private int port;

    public EmailServerSettings(string host, int port)
    {
        this.host = host;
        this.port = port;
    }
}

public interface IEmailSender
{
}
public class MessageFactory
{
}

public class NetworkClient
{
}