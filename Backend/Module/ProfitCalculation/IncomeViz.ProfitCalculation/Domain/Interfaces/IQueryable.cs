using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Domain.Interfaces
{
    internal interface IQueryable
    {
        string GetName();
        Money GetMoney();
    }
}