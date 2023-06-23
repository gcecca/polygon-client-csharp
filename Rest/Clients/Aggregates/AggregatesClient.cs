using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Polygon
{
    internal class AggregatesClient 
    {
        private HttpPolygonClient HttpClient;

        internal AggregatesClient(HttpPolygonClient _Client)
        {
            HttpClient = _Client;

        }

        internal async Task<Aggregates?> AggregatesBars(string ticker, int multiplier, PolygonTimeSpan timeSpan, DateTime from, DateTime to, string? QueryStringParameters = null)
        {
            string requestUri =
                PolygonEndpoint.Url($"{Aggregates.BaseUrl}ticker/{ticker}/range/{multiplier}/{timeSpan}/{from.ToString("yyyy-MM-dd")}/{to.ToString("yyyy-MM-dd")}",
                                       HttpClient.APIKey, QueryStringParameters);
            return await HttpClient.MakeGenericRequest<Aggregates?>(requestUri);

        }

        internal async Task<List<AggregatesItem>?> AggregatesBarsResults(string ticker, int multiplier,
                                                                PolygonTimeSpan timeSpan, DateTime from, DateTime to, string? QueryStringParameters = null)
        {
            List<AggregatesItem> AggsItemsList = new();
            Aggregates? AggregatesElement = await AggregatesBars(ticker, multiplier, timeSpan, from, to, QueryStringParameters);

            if (AggregatesElement is not null && AggregatesElement.NextUrl is null) return AggregatesElement.Results;

            while (AggregatesElement is not null && AggregatesElement.NextUrl is not null)
            {
                AggsItemsList.AddRange(AggregatesElement.Results);
                AggregatesElement = await AggregatesBars(ticker, multiplier, timeSpan, from, to, QueryStringParameters);
            }

            return AggsItemsList;
        }


        internal async Task<Aggregates?> GroupedDaily(DateTime date, string? QueryStringParameters = null)
        {
            string requestUri =
                PolygonEndpoint.Url($"{Aggregates.BaseUrl}grouped/locale/us/market/stocks/{date.ToString("yyyy-MM-dd")}",
                                       HttpClient.APIKey, QueryStringParameters);
            return await HttpClient.MakeGenericRequest<Aggregates?>(requestUri);
        }

        internal async Task<Aggregates?> PreviousClose(string ticker, string? QueryStringParameters = null)
        {
            string requestUri = PolygonEndpoint.Url($"{Aggregates.BaseUrl}ticker/{ticker}/prev", HttpClient.APIKey, QueryStringParameters);
            Console.WriteLine(requestUri);
            return await HttpClient.MakeGenericRequest<Aggregates?>(requestUri); 
        }


    }
}
