using System;

namespace IncomeViz.ProfitCalculation.Domain.Interfaces
{
    internal interface IShortTerm : IQueryable
    {
        DateTime GetExecutionDate();
    }
}
