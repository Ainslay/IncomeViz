using System;
using System.Threading.Tasks;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction
{
    public interface IReadPredictionRepository
    {
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetShortPredictionById(Guid predictionId);
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetFullPredictionById(Guid predictionId);
    }
}
