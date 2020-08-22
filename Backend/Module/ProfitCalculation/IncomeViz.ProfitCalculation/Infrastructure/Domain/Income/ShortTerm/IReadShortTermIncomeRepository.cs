using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Income.ShortTerm;

namespace IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.ShortTerm
{
    public interface IReadShortTermIncomeRepository
    {
        Task<ShortTermIncome> GetShortTermIncomeById(Guid shortTermIncomeId);
        Task<ICollection<ShortTermIncome>> GetShortTermIncomes();
    }
}
