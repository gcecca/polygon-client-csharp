using System.Text.Json;

namespace Polygon;

internal class HttpPolygonClient
{
    private HttpClient Client;
    internal string APIKey { get; }

    internal HttpPolygonClient(string _APIKey)
    {
        Client = new();
        APIKey = _APIKey;
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.BaseAddress = new Uri("https://api.polygon.io/");

    }

    internal async Task<Stream> MakeRequest(string request)
    {
        return await Client.GetStreamAsync(request);
    }

    internal async Task<T?> MakeGenericRequest<T> (string request)
    {
        Console.WriteLine($"Making this request: {request}");
        try
        {
            var response = await MakeRequest(request);
            var TObject = await JsonSerializer.DeserializeAsync<T>(response);
            return TObject;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return default;
        }
    }   

}
