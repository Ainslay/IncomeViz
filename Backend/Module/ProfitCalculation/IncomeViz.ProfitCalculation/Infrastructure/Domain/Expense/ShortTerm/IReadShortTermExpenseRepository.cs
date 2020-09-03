using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm
{
    public interface IReadShortTermExpenseRepository
    {
        Task<ICollection<ShortTermExpense>> GetShortTermExpenses(Guid predictionId);
    }
}
