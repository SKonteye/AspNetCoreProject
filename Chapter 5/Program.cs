//* Json API with minimal API*//
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();
var people = new List<Person>
{
    new Person("Moussa", "Diop"),
    new Person("Abdou", "Fall"),
    new Person("Fatou", "Toure"),
    new Person("Awa", "Kasse")
};

app.MapGet("/person/{name}", (string name) =>
people.Where(p => p.firstName.StartsWith(name)));
app.Run();
public record Person(string firstName, string lastName);