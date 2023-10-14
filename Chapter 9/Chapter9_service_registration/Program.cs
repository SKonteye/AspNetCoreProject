var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddSingleton<NetworkClient>();
builder.Services.AddScoped<MessageFactory>();
var app = builder.Build();

app.MapGet("register/{username}", RegisterUser);

app.Run();

//string RegisterUser(string username)
//{
//    IEmailSender emailSender = new EmailSender(
//        new MessageFactory(),
//        new NetworkClient(
//            new EmailServerSettings
//            (
//                Host: "smtp.server.com",
//                Port: 25))
//        );
//    emailSender.SendEmail(username);
//    return $"Email sent to {username}";
//}

string RegisterUser(string username, IEmailSender emailSender)
{
    emailSender.SendEmail(username);
    return $"Email sent to {username}";
}