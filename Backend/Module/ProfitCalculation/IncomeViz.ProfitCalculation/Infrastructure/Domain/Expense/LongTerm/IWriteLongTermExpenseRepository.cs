using System;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Expense.LongTerm;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.LongTerm
{
    public interface IWriteLongTermExpenseRepository
    {
        Task SaveAsync();
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionByPredictionId(Guid predictionId);
        Task<LongTermExpense> GetLongTermExpenseById(Guid longTermExpenseId);
        void UpdateLongTermExpense(LongTermExpense longTermExpense);
    }
}
