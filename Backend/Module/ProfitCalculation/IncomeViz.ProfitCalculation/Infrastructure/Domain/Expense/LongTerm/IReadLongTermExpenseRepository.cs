using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Expense.LongTerm;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.LongTerm
{
    public interface IReadLongTermExpenseRepository
    {
        Task<ICollection<LongTermExpense>> GetLongTermExpenses(Guid predictionId);
    }
}
