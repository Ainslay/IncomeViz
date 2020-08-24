using System;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Expense.LongTerm;
using Microsoft.EntityFrameworkCore;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using MediatR;

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

        public async Task<LongTermExpense> GetLongTermExpenseById(Guid longTermExpenseId)
        {
            return await _db.LongTermExpenses.SingleOrDefaultAsync(lte => lte.EntityId.Equals(longTermExpenseId))
                ?? throw new NullReferenceException(nameof(longTermExpenseId));
        }

        public async Task<Unit> DeleteLongTermExpense(Guid longTermExpenseId)
        {
            var longTermExpenseToDelete = await _db.LongTermExpenses.SingleOrDefaultAsync(lte => lte.EntityId.Equals(longTermExpenseId))
                ?? throw new NullReferenceException(nameof(longTermExpenseId));

            _db.LongTermExpenses.Remove(longTermExpenseToDelete);

            return  Unit.Value;
        }

        public void UpdateLongTermExpense(LongTermExpense longTermExpense)
        {
            _db.LongTermExpenses.Update(longTermExpense);
        }
    }
}
