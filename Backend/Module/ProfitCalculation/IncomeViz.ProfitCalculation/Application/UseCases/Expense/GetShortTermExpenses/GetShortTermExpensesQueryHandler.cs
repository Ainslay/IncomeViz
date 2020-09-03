using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Expense.ShortTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Expense.GetShortTermExpenses
{
    public class GetShortTermExpensesQueryHandler : IRequestHandler<GetShortTermExpensesQuery, ICollection<ShortTermExpenseDto>>
    {
        private readonly IReadShortTermExpenseRepository _repository;

        public GetShortTermExpensesQueryHandler(IReadShortTermExpenseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<ShortTermExpenseDto>> Handle(GetShortTermExpensesQuery query,
            CancellationToken cancellationToken)
        {
            var shortTermExpenses = await _repository.GetShortTermExpenses(query.PredictionId);

            return shortTermExpenses.Select(expense => new ShortTermExpenseDto(expense)).ToList();
        }
    }
}
