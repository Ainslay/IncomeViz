using System;
using System.Threading.Tasks;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.LongTerm
{
    internal interface IWriteLongTermExpenseRepository
    {
        Task SaveAsync();
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionByPredictionId(Guid predictionId);
    }
}