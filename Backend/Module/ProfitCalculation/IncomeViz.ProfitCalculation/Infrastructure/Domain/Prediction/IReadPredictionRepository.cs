using System;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Prediction;
namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction
{
    public interface IReadPredictionRepository
    {
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionByPredictionId(Guid predictionId);
    }
}
