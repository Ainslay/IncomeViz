using System;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm
{
    public interface IWriteShortTermExpenseRepository
    {
        Task SaveAsync();
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionByPredictionId(Guid predictionId);
        Task<ShortTermExpense> GetShortTermExpenseById(Guid shortTermExpenseId);
        void UpdateShortTermExpense(ShortTermExpense shortTermExpense);
    }
}
