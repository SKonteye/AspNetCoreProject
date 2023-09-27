using Fruit;

IFruitClient client = new FruitClient(
    new HttpClient() { BaseAddress =
    new Uri ("https://localhost:7282")
    });

Fruit.Fruit created = await client.FruitPAsync("123",
    new Fruit.Fruit { Name = "Banana", Stock = 100 });
Console.WriteLine($"Created {created.Name}");

Fruit.Fruit fetched = await client.FruitGAsync("123");
Console.WriteLine($"Fetched {fetched.Name}");