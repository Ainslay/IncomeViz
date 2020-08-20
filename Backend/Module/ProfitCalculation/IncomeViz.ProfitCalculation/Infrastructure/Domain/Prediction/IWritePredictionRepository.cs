using System;
using System.Threading.Tasks;
using MediatR;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction
{
    public interface IWritePredictionRepository
    {
        Task<Guid> AddAndSave(ProfitCalculation.Domain.Prediction.Prediction prediction);
        Task<Unit> DeleteAndSave(Guid predictionId);
    }
}
