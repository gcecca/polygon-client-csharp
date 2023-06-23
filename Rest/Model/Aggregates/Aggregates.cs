using System.Collections.Generic;
using System.Text.Json.Serialization;
using Polygon;

namespace Polygon; 
public record class Aggregates(
    [property: JsonPropertyName("ticker")] string Ticker,
    [property: JsonPropertyName("queryCount")] int QueryCount,
    [property: JsonPropertyName("resultCount")] int ResultCount,
    [property: JsonPropertyName("next_url")] string NextUrl,
    [property: JsonPropertyName("adjusted")] bool Adjusted,
    [property: JsonPropertyName("results")] List<AggregatesItem> Results,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("request_id")] string RequestID,
    [property: JsonPropertyName("count")] int Count)
{
    public static string BaseUrl => "v2/aggs/";
};


public enum PolygonTimeSpan
{
    minute,
    hour,
    day,
    week,
    month,
    quarter,
    year
}