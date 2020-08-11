using System;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using System.Threading.Tasks;
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

        public async Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionByPredictionId(Guid predictionId)
        {
            return await _db.Predictions.Include(p => p.LongTermIncomes)
                       .SingleOrDefaultAsync(p => p.EntityId.Equals(predictionId))
                   ??
                   throw new NullReferenceException(nameof(predictionId));
        }
    }
}