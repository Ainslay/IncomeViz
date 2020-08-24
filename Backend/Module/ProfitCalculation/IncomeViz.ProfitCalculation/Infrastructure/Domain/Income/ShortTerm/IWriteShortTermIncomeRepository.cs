using System;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Income.ShortTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.ShortTerm
{
    public interface IWriteShortTermIncomeRepository
    {
        Task SaveAsync();
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionById(Guid predictionId);
        Task<ShortTermIncome> GetShortTermIncomeById(Guid shortTermIncomeId);

        Task<Unit> DeleteShortTermIncome(Guid shortTermIncomeId);
        void UpdateShortTermIncome(ShortTermIncome income);
    }
}
