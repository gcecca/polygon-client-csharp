using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon;

internal static class PolygonEndpoint
{
    internal static string Url(string BaseUrl, string ApiKey, string? QueryStringParameters) => $"{BaseUrl}?apiKey={ApiKey}&{QueryStringParameters ?? ""}";
    internal static string Url(string BaseUrl, string ApiKey) => $"{BaseUrl}?apiKey={ApiKey}";
    
}
