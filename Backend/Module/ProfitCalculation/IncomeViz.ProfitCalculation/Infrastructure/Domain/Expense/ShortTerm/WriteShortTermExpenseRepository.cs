using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IncomeViz.ProfitCalculation.Infrastructure.Database;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm
{
    internal class WriteShortTermExpenseRepository : IWriteShortTermExpenseRepository
    {
        private readonly ProfitCalculationDbContext _db;

        public WriteShortTermExpenseRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionByPredictionId(Guid predictionId)
        {
            return await _db.Predictions.Include(p => p.ShortTermExpenses)
                       .SingleOrDefaultAsync(p => p.EntityId.Equals(predictionId))
                   ??
                   throw new NullReferenceException(nameof(predictionId));
        }
    }
}