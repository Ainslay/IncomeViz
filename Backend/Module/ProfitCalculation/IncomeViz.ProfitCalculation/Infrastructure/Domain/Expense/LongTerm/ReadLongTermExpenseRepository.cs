using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Expense.LongTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.LongTerm
{
    internal class ReadLongTermExpenseRepository : IReadLongTermExpenseRepository
    {
        private readonly ProfitCalculationDbContext _db;

        public ReadLongTermExpenseRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<LongTermExpense>> GetLongTermExpenses(Guid predictionId)
        {
            var prediction = await _db.Predictions.Include(p => p.LongTermExpenses)
                                 .SingleOrDefaultAsync(p => p.EntityId.Equals(predictionId))
                             ?? throw new NullReferenceException(nameof(predictionId));

            return prediction.LongTermExpenses.ToList();
        }
    }
}
