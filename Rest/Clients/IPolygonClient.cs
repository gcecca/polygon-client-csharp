
namespace Polygon
{
    public interface IPolygonClient
    {

        /// <summary>
        /// AggregatesBars fetch the result of the API call, use NextUrl to get the next endpoint or use AggregatesItemsList
        /// </summary>
        /// <param name="multiplier"> the timespan multiplier (if timespan is minute and multiplier is 5 the bars will be 5 minute bars)</param>
        /// <param name="timeSpan"></param>
        /// <param name="from">start date</param>
        /// <param name="to">end date</param>
        /// <param name="QueryStringParameters">additional parameters</param>
        /// <returns></returns>
        public Task<Aggregates?> AggregatesBars(string ticker, int multiplier,
                                                PolygonTimeSpan timeSpan, DateTime from,
                                                DateTime to, string? QueryStringParameters = null);

        /// <summary>
        /// fetch and merges the results fields of the API call and any subsequent result provided via next urls.
        /// </summary>
        /// <param name="ticker">
        /// the stock ticker
        /// </param>
        /// <param name="multiplier"> the timespan multiplier (if timespan is minute and multiplier is 5 the bars will be 5 minute bars)</param>
        /// <param name="timeSpan"></param>
        /// <param name="from">start date</param>
        /// <param name="to">end date</param>
        /// <param name="QueryStringParameters">additional parameters</param>
        /// <returns></returns>
        public Task<List<AggregatesItem>?> AggregatesBarsResults(string ticker, int multiplier,
                                                              PolygonTimeSpan timeSpan, DateTime from, DateTime to, string? QueryStringParameters = null);
        /// <summary>
        /// get daily Aggregates for each available stock ticker
        /// </summary>
        /// <param name="date"></param>
        /// <param name="QueryStringParameters"></param>
        /// <returns></returns>
        public Task<Aggregates?> GroupedDaily(DateTime date, string? QueryStringParameters = null);

        public Task<DailyOpenClose?> GetDailyOpenClose(string ticker, DateTime date);
        public Task<Aggregates?> PreviousClose(string ticker, string? QueryStringParameters = null);
        public Task<FinancialData?> StockFinancials(string ticker, string? QueryStringParameters = null);
        public Task<List<FinancialResult>> StockFinancialsResults(string ticker, string? QueryStringParameters = null);
        public Task<Dividends?> GetDividends(string ticker, string? QueryStringParameters = null);
    }
}
