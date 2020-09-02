using System;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Income.LongTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm
{
    internal class WriteLongTermIncomeRepository : IWriteLongTermIncomeRepository
    {
        private readonly ProfitCalculationDbContext _db;

        public WriteLongTermIncomeRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        async Task IWriteLongTermIncomeRepository.SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionById(Guid predictionId)
        {
            return await _db.Predictions.Include(p => p.LongTermIncomes)
                       .SingleOrDefaultAsync(p => p.EntityId.Equals(predictionId))
                   ??
                   throw new NullReferenceException(nameof(predictionId));
        }

        public async Task<Unit> DeleteLongTermIncome(Guid longTermIncomeId)
        {
            var longTermIncome =
                await _db.LongTermIncomes.SingleOrDefaultAsync(lti => lti.EntityId.Equals(longTermIncomeId))
                ?? throw new NullReferenceException(nameof(longTermIncomeId));

            _db.LongTermIncomes.Remove(longTermIncome);

            return Unit.Value;
        }

        public async Task<LongTermIncome> GetLongTermIncomeById(Guid longTermIncomeId)
        {
            return await _db.LongTermIncomes.SingleOrDefaultAsync(lti => lti.EntityId == longTermIncomeId)
                   ?? throw new NullReferenceException(nameof(longTermIncomeId));
        }

        public void UpdateLongTermIncome(LongTermIncome longTermIncome)
        {
            _db.LongTermIncomes.Update(longTermIncome);
        }
    }
}
