// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using JSONExample.model;
using RestSharp;
using RestSharp.Serializers.Json;

RestClientOptions options = new RestClientOptions("https://jsonplaceholder.typicode.com");
JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

RestClient client = new RestClient(
    options,
    configureSerialization: (s) => s.UseSystemTextJson(serializerOptions));

RestRequest request = new RestRequest("users/7");

User? response = await client.GetAsync<User>(request);

if (response == null)
{
    Console.WriteLine("Error!");
}
else
{
    Console.Write(response.ToString());
}
