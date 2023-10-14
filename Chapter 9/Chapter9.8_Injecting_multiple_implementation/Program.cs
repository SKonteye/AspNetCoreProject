var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IMessageSender, EmailSender>();
builder.Services.AddScoped<IMessageSender, SmsSender>();
builder.Services.AddScoped<IMessageSender, FacebookSender>();

var app = builder.Build();

app.MapGet("/register/{username}", RegisterUser);

string RegisterUser(string username,
    IEnumerable<IMessageSender> senders)
{
    foreach (var sender in senders)
    {
        sender.SendMessage($"Hello {username}");
    }
    return $"Welcome message sent to {username}";
}

app.Run();

public interface IMessageSender
{
    void SendMessage(string message);
}
public class EmailSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine(message);
    }
}
public class SmsSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine(message);
    }
}

public class FacebookSender : IMessageSender
{
    public void SendMessage(string message)
    {
        Console.WriteLine(message);
    }
}

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