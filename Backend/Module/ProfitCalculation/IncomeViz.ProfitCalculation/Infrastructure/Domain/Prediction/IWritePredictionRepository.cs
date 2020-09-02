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
    }
}
