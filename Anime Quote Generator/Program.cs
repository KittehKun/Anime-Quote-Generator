//The purpose of this application is to generate a random anime quote given a rest response from the animechan api
using Anime_Quote_Generator;
using Newtonsoft.Json;
using System.Net.Http.Headers;

//Set up the client - Code snippet from https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/console-webapiclient
using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear(); //Clear the default headers
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")); //Add the new header
client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter"); //Add the user agent header

await ProcessRepositoriesAsync(client);

static async Task ProcessRepositoriesAsync(HttpClient client)
{
    string url = "https://animechan.xyz/api/random";
    var json = await client.GetStringAsync(url);

    AnimeQuote? quote = JsonConvert.DeserializeObject<AnimeQuote>(json);
    Console.WriteLine(quote!.ToString());
}