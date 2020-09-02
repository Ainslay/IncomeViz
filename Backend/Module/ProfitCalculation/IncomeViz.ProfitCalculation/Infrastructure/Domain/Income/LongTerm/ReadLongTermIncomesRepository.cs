using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Income.LongTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm
{
    internal class ReadLongTermIncomesRepository : IReadLongTermIncomeRepository
    {
        private ProfitCalculationDbContext _db;

        public ReadLongTermIncomesRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task<LongTermIncome> GetLongTermIncomeById(Guid longTermIncomeId)
        {
            return await _db.LongTermIncomes.SingleOrDefaultAsync(lti => lti.EntityId.Equals(longTermIncomeId))
                   ?? throw new NullReferenceException(nameof(longTermIncomeId));
        }

        public async Task<ICollection<LongTermIncome>> GetLongTermIncomes()
        {
            return await _db.LongTermIncomes.ToListAsync();
        }
    }
}
