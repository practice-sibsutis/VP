// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using JSONExample;
using JSONExample.model;

HttpClient client = new HttpClient()
{
    BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
};

using HttpResponseMessage response = await client.GetAsync("users/3");

response.EnsureSuccessStatusCode();

var jsonResponse = await response.Content.ReadAsStringAsync();

Console.WriteLine(jsonResponse);
Console.WriteLine();
Console.WriteLine();

JsonSerializerOptions serializeOptions = new JsonSerializerOptions()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

User? user = JsonSerializer.Deserialize<User>(jsonResponse, serializeOptions);

if (user == null)
{
    Console.WriteLine("Error!");
}
else
{
    Console.WriteLine($"{user}");
}
