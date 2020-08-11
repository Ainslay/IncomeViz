using System;

namespace IncomeViz.ProfitCalculation.Domain.Interfaces
{
    internal interface ILongTerm : IQueryable
    {
        int GetExecutionDay();
        bool IsDateInValidRange(DateTime date);
    }
}