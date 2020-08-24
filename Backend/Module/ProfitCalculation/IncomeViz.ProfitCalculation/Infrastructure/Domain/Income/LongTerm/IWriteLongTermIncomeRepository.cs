using System;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Income.LongTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm
{
    public interface IWriteLongTermIncomeRepository
    {
        Task SaveAsync();
        Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionById(Guid predictionId);
        Task<Unit> DeleteLongTermIncome(Guid longTermIncomeId);
        Task<LongTermIncome> GetLongTermIncomeById(Guid longTermIncomeId);
        void UpdateLongTermIncome(LongTermIncome longTermIncome);
    }
}
