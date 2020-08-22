using System;
using System.Threading.Tasks;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm
{
    public interface IWriteLongTermIncomeRepository
    {
        Task SaveAsync();
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionById(Guid predictionId);
    }
}
