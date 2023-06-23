using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;

namespace Polygon;
internal class FinancialsClient
{
    private HttpPolygonClient HttpClient;

    internal FinancialsClient(HttpPolygonClient _base)
    {
        HttpClient = _base;
    }

    internal async Task<FinancialData?> StockFinancials(string ticker, string? QueryStringParameters = null)
    {
        string requestUri = 
            PolygonEndpoint.Url($"{FinancialData.BaseUrl}",
                                   HttpClient.APIKey, $"{QueryStringParameters ?? ""}&ticker={ticker}");
        return await HttpClient.MakeGenericRequest<FinancialData?>(requestUri);
    }

    internal async Task<List<FinancialResult>> StockFinancialsResults(string ticker, string? QueryStringParameters = null)
    {
        List<FinancialResult> FinancialResults = new();
        FinancialData? FinancialDataElement = await StockFinancials(ticker, QueryStringParameters);

        if (FinancialDataElement is not null && FinancialDataElement.next_url is null) return FinancialDataElement.results;

        while (FinancialDataElement is not null && FinancialDataElement.next_url is not null)
        {
            FinancialResults.AddRange(FinancialDataElement.results);
            FinancialDataElement = await HttpClient.MakeGenericRequest<FinancialData>($"{FinancialDataElement.next_url}&apiKey={HttpClient.APIKey}");
        }

        return FinancialResults;

    }

}
