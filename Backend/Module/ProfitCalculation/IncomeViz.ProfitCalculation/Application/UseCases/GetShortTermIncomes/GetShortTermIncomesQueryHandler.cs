using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.ShortTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.GetShortTermIncomes
{
    public class GetShortTermIncomesQueryHandler : IRequestHandler<GetShortTermIncomesQuery, ICollection<ShortTermIncomeDto>>
    {
        private IReadShortTermIncomeRepository _repository;

        public GetShortTermIncomesQueryHandler(IReadShortTermIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<ShortTermIncomeDto>> Handle(GetShortTermIncomesQuery query, CancellationToken cancellationToken)
        {
            var shortTermIncomes = await _repository.GetShortTermIncomes();
            var shortTermIncomesDto = new List<ShortTermIncomeDto>();

            foreach (var income in shortTermIncomes)
            {
                shortTermIncomesDto.Add(new ShortTermIncomeDto(income.EntityId, income.GetName(), income.GetExecutionDate(),
                    income.GetMoney().GetAmount(), income.GetMoney().GetCurrency()));
            }

            return shortTermIncomesDto;
        }
    }
}
