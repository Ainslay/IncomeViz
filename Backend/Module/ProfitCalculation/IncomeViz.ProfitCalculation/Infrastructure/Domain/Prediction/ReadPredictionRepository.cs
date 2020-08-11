using IncomeViz.ProfitCalculation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Prediction
{
    public class ReadPredictionRepository : IReadPredictionRepository
    {
        private readonly ProfitCalculationDbContext _db;

        public ReadPredictionRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionByPredictionId(Guid predictionId)
        {
            return await _db.Predictions
                .Include(p => p.ShortTermIncomes)
                .Include(p => p.LongTermIncomes)
                .Include(p => p.ShortTermExpenses)
                .Include(p => p.LongTermExpenses)
                .SingleOrDefaultAsync(p => p.EntityId.Equals(predictionId))
                   ??
                   throw new NullReferenceException(nameof(predictionId));
        }
    }
}
