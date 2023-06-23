namespace Polygon
{
    public record class FinancialData(
        int count,
        string next_url,
        string request_id,
        List<FinancialResult> results,
        string status)
    {
        public static string BaseUrl => "vX/reference/financials";
    }

    public record class FinancialResult(
        string cik,
        string company_name,
        string end_date,
        string filing_date,
        Financials financials,
        string fiscal_period,
        string fiscal_year,
        string source_filing_file_url,
        string source_filing_url,
        string start_date,
        string timeframe);

    public record class Financials(
        BalanceSheet balance_sheet,
        CashFlowStatement cash_flow_statement ,
        ComprehensiveIncome comprehensive_income,
        IncomeStatement income_statement);

    public record class BalanceSheet(
        FinancialsItem assets ,
        FinancialsItem current_liabilities ,
        FinancialsItem equity,
        FinancialsItem equity_attributable_to_noncontrolling_interest ,
        FinancialsItem equity_attributable_to_parent ,
        FinancialsItem liabilities,
        FinancialsItem liabilities_and_equity ,
        FinancialsItem noncurrent_assets,
        FinancialsItem noncurrent_liabilities);

    public record class CashFlowStatement(

        FinancialsItem exchange_gains_losses ,
        FinancialsItem net_cash_flow,
        FinancialsItem net_cash_flow_continuing,
        FinancialsItem net_cash_flow_from_financing_activities,
        FinancialsItem net_cash_flow_from_financing_activities_continuing ,
        FinancialsItem net_cash_flow_from_investing_activities ,
        FinancialsItem net_cash_flow_from_investing_activities_continuing ,
        FinancialsItem net_cash_flow_from_operating_activities ,
        FinancialsItem net_cash_flow_from_operating_activities_continuing);

    public record class ComprehensiveIncome
    (
        FinancialsItem comprehensive_income_loss,
        FinancialsItem comprehensive_income_loss_attributable_to_noncontrolling_interest,
        FinancialsItem comprehensive_income_loss_attributable_to_parent,
        FinancialsItem other_comprehensive_income_loss,
        FinancialsItem other_comprehensive_income_loss_attributable_to_parent);

    public record class IncomeStatement(

        FinancialsItem basic_earnings_per_share,
        FinancialsItem benefits_costs_expenses,
        FinancialsItem costs_and_expenses,
        FinancialsItem diluted_earnings_per_share,
        FinancialsItem gross_profit,
        FinancialsItem income_loss_from_continuing_operations_after_tax,
        FinancialsItem income_loss_from_continuing_operations_before_tax,
        FinancialsItem income_tax_expense_benefit,
        FinancialsItem interest_expense_operating,
        FinancialsItem net_income_loss,
        FinancialsItem net_income_loss_attributable_to_noncontrolling_interest,
        FinancialsItem net_income_loss_attributable_to_parent,
        FinancialsItem net_income_loss_available_to_common_stockholders_basic,
        FinancialsItem operating_expenses,
        FinancialsItem operating_income_loss,
        FinancialsItem participating_securities_distributed_and_undistributed_earnings_loss_basic,
        FinancialsItem preferred_stock_dividends_and_other_adjustments,
        FinancialsItem revenues);

    public record class FinancialsItem(
        string label,
        int order,
        string unit,
        decimal value);
}
