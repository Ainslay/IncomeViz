using System;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.ShortTerm
{
    internal class WriteShortTermIncomeRepository : IWriteShortTermIncomeRepository
    {
        private readonly ProfitCalculationDbContext _db;

        public WriteShortTermIncomeRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionById(Guid predictionId)
        {
            return await _db.Predictions.Include(p => p.ShortTermIncomes)
                       .SingleOrDefaultAsync(p => p.EntityId.Equals(predictionId))
                   ??
                   throw new NullReferenceException(nameof(predictionId));
        }
    }
}