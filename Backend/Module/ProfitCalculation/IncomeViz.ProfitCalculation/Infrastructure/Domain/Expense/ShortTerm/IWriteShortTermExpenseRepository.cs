using System;
using System.Threading.Tasks;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm
{
    public interface IWriteShortTermExpenseRepository
    {
        Task SaveAsync();
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionByPredictionId(Guid predictionId);
    }
}