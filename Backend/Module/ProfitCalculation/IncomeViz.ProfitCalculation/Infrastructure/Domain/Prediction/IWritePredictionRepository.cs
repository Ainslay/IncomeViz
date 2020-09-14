using System;
using System.Threading.Tasks;
using MediatR;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction
{
    public interface IWritePredictionRepository
    {
        Task SaveAsync();
        Task<Unit> AddPrediction(ProfitCalculation.Domain.Prediction.Prediction prediction);
        Task<Unit> DeletePredictionById(Guid predictionId);
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionById(Guid predictionId);
        void UpdatePrediction(ProfitCalculation.Domain.Prediction.Prediction prediction);
    }
}
