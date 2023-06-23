using System;
using System.Text.Json;

namespace Polygon;

internal class DailyOpenCloseClient
{
    private HttpPolygonClient HttpClient;

    internal DailyOpenCloseClient(HttpPolygonClient _base)
    {
        HttpClient = _base;
    }


    internal async Task<DailyOpenClose?> GetDailyOpenClose(string ticker, DateTime date, bool adjusted=false)
    {
        string requestUri = PolygonEndpoint.Url($"{DailyOpenClose.BaseUrl}/{ticker}/{date.ToString("yyyy-MM-dd")}",
                                                   HttpClient.APIKey, QueryStringParameters:$"adjusted={adjusted}");
        return await HttpClient.MakeGenericRequest<DailyOpenClose?>(requestUri);
    }



}
