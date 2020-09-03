using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Income.LongTerm;
using IncomeViz.ProfitCalculation.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm
{
    internal class ReadLongTermIncomesRepository : IReadLongTermIncomeRepository
    {
        private readonly ProfitCalculationDbContext _db;

        public ReadLongTermIncomesRepository(ProfitCalculationDbContext db)
        {
            _db = db;
        }

        public async Task<LongTermIncome> GetLongTermIncomeById(Guid longTermIncomeId)
        {
            return await _db.LongTermIncomes.SingleOrDefaultAsync(lti => lti.EntityId.Equals(longTermIncomeId))
                   ?? throw new NullReferenceException(nameof(longTermIncomeId));
        }

        public async Task<ICollection<LongTermIncome>> GetLongTermIncomes(Guid predictionId)
        {
            var prediction = await _db.Predictions.Include(p => p.LongTermIncomes).SingleOrDefaultAsync(p => p.EntityId.Equals(predictionId))
                    ?? throw new NullReferenceException(nameof(predictionId));

            return prediction.LongTermIncomes.ToList();
        }
    }
}
