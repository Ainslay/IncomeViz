using System;
using System.Threading.Tasks;
using MediatR;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.ShortTerm
{
    public interface IWriteShortTermIncomeRepository
    {
        Task SaveAsync();
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionById(Guid predictionId);
        Task<Unit> DeleteShortTermIncome(Guid shortTermIncomeId);
    }
}
