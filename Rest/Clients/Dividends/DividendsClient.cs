using System;
using System.Text.Json;
namespace Polygon
{
    internal class DividendsClient
    {
        HttpPolygonClient HttpClient;

        internal DividendsClient(HttpPolygonClient _Client)
        {
            HttpClient = _Client;
        }

        internal async Task<Dividends?> GetDividends(string ticker, string? QueryStringParameters = null)
        {
            string requestUri = PolygonEndpoint.Url($"{Dividends.BaseUrl}",
                                HttpClient.APIKey, $"{QueryStringParameters ?? ""}&ticker={ticker}");
            return await HttpClient.MakeGenericRequest<Dividends?>(requestUri);
        }

    }
}