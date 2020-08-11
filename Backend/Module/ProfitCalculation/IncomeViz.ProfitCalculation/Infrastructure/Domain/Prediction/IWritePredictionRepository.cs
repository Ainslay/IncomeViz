using System;
using System.Threading.Tasks;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction
{
    public interface IWritePredictionRepository
    {
        Task<Guid> AddAndSave(ProfitCalculation.Domain.Prediction.Prediction prediction);
    }
}