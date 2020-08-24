using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Expense.LongTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.LongTerm
{
    class ReadLongTermExpenseRepository : IReadLongTermExpenseRepository
    {
        private readonly ProfitCalculationDbContext _db;

        public ReadLongTermExpenseRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<LongTermExpense>> GetLongTermExpenses()
        {
            return await _db.LongTermExpenses.ToListAsync();
        }
    }
}
