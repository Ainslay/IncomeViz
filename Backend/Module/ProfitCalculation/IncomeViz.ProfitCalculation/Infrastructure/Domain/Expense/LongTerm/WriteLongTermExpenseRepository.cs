using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IncomeViz.ProfitCalculation.Infrastructure.Database;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.LongTerm
{
    internal class WriteLongTermExpenseRepository : IWriteLongTermExpenseRepository
    {
        private readonly ProfitCalculationDbContext _db;

        public WriteLongTermExpenseRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<ProfitCalculation.Domain.Prediction.Prediction> GetPredictionByPredictionId(Guid predictionId)
        {
            return await _db.Predictions.Include(p => p.LongTermExpenses)
                       .SingleOrDefaultAsync(p => p.EntityId.Equals(predictionId))
                   ??
                   throw new NullReferenceException(nameof(predictionId));
        }
    }
}