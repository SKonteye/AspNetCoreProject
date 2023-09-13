

using Chapter8._1;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/register/{username}", RegisterUser);

app.Run();

//string RegisterUser(string username)
//{
//    var emailSender = new EmailSender();
//    emailSender.SendEmail(username);
//    return $"Email sent to {username}";
//}

string RegisterUser(string username, IEmailSender emailSender)
{
    emailSender.SendEmail(username);
    return $"Email sent to {username}";
}