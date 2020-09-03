using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using IncomeViz.ProfitCalculation.Infrastructure.Domain.Income.LongTerm;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Income.GetLongTermIncomes
{
    public class
        GetLongTermIncomesQueryHandler : IRequestHandler<GetLongTermIncomesQuery, ICollection<LongTermIncomeDto>>
    {
        private readonly IReadLongTermIncomeRepository _repository;

        public GetLongTermIncomesQueryHandler(IReadLongTermIncomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<LongTermIncomeDto>> Handle(GetLongTermIncomesQuery query,
            CancellationToken cancellationToken)
        {
            var longTermIncomes = await _repository.GetLongTermIncomes(query.PredictionId);

            return longTermIncomes.Select(income => new LongTermIncomeDto(income)).ToList();
        }
    }
}
