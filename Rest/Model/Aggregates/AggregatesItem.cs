
using System.Text.Json.Serialization;

namespace Polygon;
    public record class AggregatesItem(
        [property: JsonPropertyName("T")] string Ticker,
        [property: JsonPropertyName("v")] float V,
        [property: JsonPropertyName("vw")] float Vw,
        [property: JsonPropertyName("o")] float Open,
        [property: JsonPropertyName("c")] float Close,
        [property: JsonPropertyName("h")] float High,
        [property: JsonPropertyName("l")] float Low,
        [property: JsonPropertyName("t")] Int64 T,
        [property: JsonPropertyName("n")] int N
        );
