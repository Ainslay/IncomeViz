using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm
{
    internal class ReadShortTermExpenseRepository : IReadShortTermExpenseRepository
    {
        private readonly ProfitCalculationDbContext _db;

        public ReadShortTermExpenseRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<ShortTermExpense>> GetShortTermExpenses(Guid predictionId)
        {
            var prediction = await _db.Predictions.Include(p => p.ShortTermExpenses).SingleOrDefaultAsync(p => p.EntityId.Equals(predictionId))
                             ?? throw new NullReferenceException(nameof(predictionId));

            return prediction.ShortTermExpenses.ToList();
        }
    }
}
