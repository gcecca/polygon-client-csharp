# C# Polygon io client class library #

A client to retrieve data from polygon.io with c#

## Documentation ##
You can find the API docs here: https://polygon.io/docs/

## Sample Usage ##

```c#

using polygon;
IPolygonClient pc = new PolygonClient($"{API_KEY}");

DateTime Date = new DateTime(2023, 06, 06)
Console.WriteLine(await pc.GetDailyOpenClose("X:BTCUSD", Date));
Console.WriteLine(await pc.GetDailyOpenClose("AAPL", Date));

```

## Passing parameters ##

Mandatory parameters will be parameters of the interface methods. Polygon api requests may 
have optional parameters for each method that you can freely pass as query string parameters as shown in the next example.
If you need to pass multiple parameters use the query string parameter syntax

```c#

using Polygon;
IPolygonClient pc = new PolygonClient($"{API_KEY}");

DateTime _from = new DateTime(2023, 01, 01);
DateTime _to = new DateTime(2023, 06, 20);
var CryptoAggs = await pc.AggregatesBars("X:BTCUSD", 1, PolygonTimeSpan.day, _from, _to,
                                         QueryStringParameters:"adjusted=true&limit=180");
```

### TimeSpan ###

You can use the PolygonTimeSpan enum for providing timespan parameters. Alternatively you can provide the timespan as a query string parameter

## Available Methods ##

The available methods are in the IPolygonClient interface
Here are some basic methods that you can use:

```c#

/// <summary>
/// AggregatesBars fetch the result of the API call, use NextUrl to get the next endpoint 
/// or use AggregatesItemsList
/// </summary>
/// <param name="multiplier"> the timespan multiplier (if timespan is minute and multiplier is 5 
/// the bars will be 5 minute bars)</param>
/// <param name="timeSpan"></param>
/// <param name="from">start date</param>
/// <param name="to">end date</param>
/// <param name="QueryStringParameters">additional parameters</param>
/// <returns></returns>
public Task<Aggregates?> AggregatesBars(string ticker, int multiplier,
                                        PolygonTimeSpan timeSpan, DateTime from,
                                        DateTime to, string? QueryStringParameters=null);

/// <summary>
/// fetch and merges the results fields of the API call and any subsequent result provided via next urls.
/// </summary>
/// <param name="ticker">
/// the stock ticker
/// </param>
/// <param name="multiplier"> the timespan multiplier (if timespan is minute and multiplier is 5 
/// the bars will be 5 minute bars)</param>
/// <param name="timeSpan"></param>
/// <param name="from">start date</param>
/// <param name="to">end date</param>
/// <param name="QueryStringParameters">additional parameters</param>
/// <returns></returns>
public Task<List<AggregatesItem>?> AggregatesBarsResults(string ticker, int multiplier,
                                                         PolygonTimeSpan timeSpan, DateTime from, 
                                                         DateTime to, string? QueryStringParameters=null);
/// <summary>
/// get daily Aggregates for each available stock ticker
/// </summary>
/// <param name="date"></param>
/// <param name="QueryStringParameters"></param>
/// <returns></returns>
public Task<Aggregates?> GroupedDaily(DateTime date, string? QueryStringParameters=null);

public Task<DailyOpenClose?> GetDailyOpenClose(string ticker, DateTime date);
public Task<Aggregates?> PreviousClose(string ticker, string? QueryStringParameters=null);
public Task<FinancialData?> StockFinancials(string ticker, string? QueryStringParameters=null);
public Task<List<FinancialResult>> StockFinancialsResults(string ticker, string? 
                                                          QueryStringParameters=null);
public Task<Dividends?> GetDividends(string ticker, string? QueryStringParameters=null);


```