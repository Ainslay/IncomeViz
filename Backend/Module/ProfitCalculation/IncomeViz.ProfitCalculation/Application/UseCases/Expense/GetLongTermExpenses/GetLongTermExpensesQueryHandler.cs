using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.LongTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Expense.GetLongTermExpenses
{
    public class
        GetLongTermExpensesQueryHandler : IRequestHandler<GetLongTermExpensesQuery, ICollection<LongTermExpenseDto>>
    {
        private readonly IReadLongTermExpenseRepository _repository;

        public GetLongTermExpensesQueryHandler(IReadLongTermExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<LongTermExpenseDto>> Handle(GetLongTermExpensesQuery query,
            CancellationToken cancellationToken)
        {
            var longTermExpenses = await _repository.GetLongTermExpenses();

            return longTermExpenses.Select(expense => new LongTermExpenseDto(expense.EntityId, expense.GetName(),
                expense.GetExecutionDay(), expense.GetStartingDate(), expense.GetEffectiveDate(),
                expense.GetMoney().GetAmount(), expense.GetMoney().GetCurrency())).ToList();
        }
    }
}
