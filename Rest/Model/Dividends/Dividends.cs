using System.Text.Json.Serialization;

namespace Polygon;
    public record class Dividends(
        string next_url,
        List<DividendResult> results,
        string status )
    {
        public static string BaseUrl => "v3/reference/dividends";

    }

    public record class DividendResult(
        [property: JsonPropertyName("cash_amount")] double CashAmount ,
        [property: JsonPropertyName("declaration_date")] string DeclarationDate ,
        [property: JsonPropertyName("dividend_type")] string DividendType ,
        [property: JsonPropertyName("ex_dividend_date")] string ExDividendDate,
        [property: JsonPropertyName("frequency")] int Frequency ,
        [property: JsonPropertyName("pay_date")] string PayDate,
        [property: JsonPropertyName("record_date")] string RecordDate,
        [property: JsonPropertyName("ticker")] string Ticker);
