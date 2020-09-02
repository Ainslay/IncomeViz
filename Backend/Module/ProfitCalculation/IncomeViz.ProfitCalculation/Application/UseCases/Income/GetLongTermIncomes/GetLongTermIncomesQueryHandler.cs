using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Income.GetLongTermIncomes
{
    public class GetLongTermIncomesQueryHandler : IRequestHandler<GetLongTermIncomesQuery, ICollection<LongTermIncomeDto>>
    {
        private IReadLongTermIncomeRepository _repository;

        public GetLongTermIncomesQueryHandler(IReadLongTermIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<LongTermIncomeDto>> Handle(GetLongTermIncomesQuery query, CancellationToken cancellationToken)
        {
            var longTermIncomes = await _repository.GetLongTermIncomes();
            var longTermIncomesDto = new List<LongTermIncomeDto>();

            foreach (var income in longTermIncomes)
            {
                longTermIncomesDto.Add(new LongTermIncomeDto(income.EntityId, income.GetName(), income.GetExecutionDay(),
                    income.GetStartingDate(), income.GetEffectiveDate(), income.GetMoney().GetAmount(), income.GetMoney().GetCurrency()));
            }

            return longTermIncomesDto;
        }
    }
}
