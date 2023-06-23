
using System.Net.Http.Headers;
using System.Text.Json;

namespace Polygon;

/// <summary>
/// Class represents a polygon.io client
/// </summary>
public class PolygonClient : IPolygonClient
{
    private readonly HttpPolygonClient Client;
    private readonly AggregatesClient AggregatesClient;
    private readonly FinancialsClient FinancialsClient;
    private readonly DividendsClient DividendsClient;
    private readonly DailyOpenCloseClient DailyOpenCloseClient;

    /// <summary>
    /// Instantiate a new polygon client for any request from a provided api key
    /// </summary>
    /// <param name="_APIKey"></param>
    public PolygonClient(string _APIKey)
    {
        Client = new HttpPolygonClient(_APIKey);
        this.AggregatesClient = new AggregatesClient(Client);
        this.FinancialsClient = new FinancialsClient(Client);
        this.DividendsClient = new DividendsClient(Client);
        this.DailyOpenCloseClient = new DailyOpenCloseClient(Client);
    }

    public async Task<Aggregates?> AggregatesBars(string ticker, int multiplier, PolygonTimeSpan timeSpan,
                                                  DateTime from, DateTime to, string? QueryStringParameters = null)
    {
        return await AggregatesClient.AggregatesBars(ticker, multiplier, timeSpan, from, to, QueryStringParameters);
    }
    public async Task<List<AggregatesItem>?> AggregatesBarsResults(string ticker, int multiplier, PolygonTimeSpan timeSpan,
                                                                 DateTime from, DateTime to, string? QueryStringParameters = null)
    {
        return await AggregatesClient.AggregatesBarsResults(ticker, multiplier, timeSpan, from, to, QueryStringParameters);
    }
    public async Task<DailyOpenClose?> GetDailyOpenClose(string ticker, DateTime date)
    {
        return await DailyOpenCloseClient.GetDailyOpenClose(ticker, date);
    }
    public async Task<Aggregates?> GroupedDaily(DateTime date, string? QueryStringParameters = null)
    {
        return await AggregatesClient.GroupedDaily(date, QueryStringParameters);
    }
    public async Task<Aggregates?> PreviousClose(string ticker, string? QueryStringParameters = null)
    {
        return await AggregatesClient.PreviousClose(ticker, QueryStringParameters);
    }
    public async Task<FinancialData?> StockFinancials(string ticker, string? QueryStringParameters = null)
    {
        return await FinancialsClient.StockFinancials(ticker, QueryStringParameters);
    }
    public async Task<List<FinancialResult>> StockFinancialsResults(string ticker, string? QueryStringParameters = null)
    {
        return await FinancialsClient.StockFinancialsResults(ticker, QueryStringParameters);
    }
    public async Task<Dividends?> GetDividends(string ticker, string? QueryStringParameters = null)
    {
        return await DividendsClient.GetDividends(ticker, QueryStringParameters);
    }
}