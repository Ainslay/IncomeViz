using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction
{
    public interface IReadPredictionRepository
    {
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionById(Guid predictionId);
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetFullPredictionById(Guid predictionId);
        Task<ICollection<ProfitCalculation.Domain.Prediction.Prediction>> GetPredictions();
    }
}
