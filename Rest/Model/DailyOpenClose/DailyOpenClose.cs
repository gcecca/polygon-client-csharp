using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Polygon;

public record class DailyOpenClose(

    [property: JsonPropertyName("afterHours")] double AfterHours,
    [property: JsonPropertyName("close")] double Close,
    [property: JsonPropertyName("from")] string From,
    [property: JsonPropertyName("high")] double High,
    [property: JsonPropertyName("low")] double Low,
    [property: JsonPropertyName("open")] double Open,
    [property: JsonPropertyName("preMarket")] double PreMarket,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("symbol")] string Symbol,
    [property: JsonPropertyName("volume")] double Volume)
{
    public static string BaseUrl => $"v1/open-close";
}

