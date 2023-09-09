using System.ComponentModel.DataAnnotations;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapPost("/users", (UserModel user) => user.ToString())
//    .WithParameterValidation();
app.MapPost("/user/{id}",
    ([AsParameters] GetUserModel model) => $"Received {model.Id}")
    .WithParameterValidation();

app.Run();
//public record UserModel
//{
//    [Required]
//    [StringLength(100)]
//    [Display(Name ="Your Name")]
//    public string Name { get; set; }

//    [Required]
//    [EmailAddress]
//    public string Email { get; set; }
//}
struct GetUserModel
{
    [Range(1, 10)]
    public int Id { get; set; }
}