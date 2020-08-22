using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Income.ShortTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.ShortTerm
{
    public class ReadShortTermIncomeRepository : IReadShortTermIncomeRepository
    {
        private ProfitCalculationDbContext _db;

        public ReadShortTermIncomeRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task<ShortTermIncome> GetShortTermIncomeById(Guid shortTermIncomeId)
        {
            return await _db.ShortTermIncomes.SingleOrDefaultAsync(sti => sti.EntityId.Equals(shortTermIncomeId))
                ?? throw new NullReferenceException(nameof(shortTermIncomeId));
        }

        public async Task<ICollection<ShortTermIncome>> GetShortTermIncomes()
        {
            return await _db.ShortTermIncomes.ToListAsync();
        }
    }
}
