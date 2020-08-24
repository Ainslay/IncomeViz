using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Expense.ShortTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm
{
    class ReadShortTermExpenseRepository : IReadShortTermExpenseRepository
    {
        private ProfitCalculationDbContext _db;

        public ReadShortTermExpenseRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<ShortTermExpense>> GetShortTermExpenses()
        {
            return await _db.ShortTermExpenses.ToListAsync();
        }
    }
}
