using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.GetShortTermExpenses
{
    class GetShortTermExpensesQueryHandler : IRequestHandler<GetShortTermExpensesQuery, ICollection<ShortTermExpenseDto>>
    {
        private readonly IReadShortTermExpenseRepository _repository;

        public GetShortTermExpensesQueryHandler(IReadShortTermExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<ShortTermExpenseDto>> Handle(GetShortTermExpensesQuery request, CancellationToken cancellationToken)
        {
            var shortTermExpenses = await _repository.GetShortTermExpenses();
            var shortTermExpensesDto = new List<ShortTermExpenseDto>();

            foreach (var expense in shortTermExpenses)
            {
                    shortTermExpensesDto.Add(new ShortTermExpenseDto(expense.EntityId, expense.GetName(),
                        expense.GetExecutionDate(), expense.GetMoney().GetAmount(), expense.GetMoney().GetCurrency()));
            }

            return shortTermExpensesDto;
        }
    }
}
