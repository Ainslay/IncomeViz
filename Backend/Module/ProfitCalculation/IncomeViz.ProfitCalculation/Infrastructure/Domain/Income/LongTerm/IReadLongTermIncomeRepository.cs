using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Income.LongTerm;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm
{
    public interface IReadLongTermIncomeRepository
    {
        Task<LongTermIncome> GetLongTermIncomeById(Guid longTermIncomeId);
        Task<ICollection<LongTermIncome>> GetLongTermIncomes(Guid predictionId);
    }
}
