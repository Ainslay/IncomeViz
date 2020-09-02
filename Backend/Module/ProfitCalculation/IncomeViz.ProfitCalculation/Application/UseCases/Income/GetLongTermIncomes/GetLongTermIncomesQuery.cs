using System.Collections.Generic;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Income.GetLongTermIncomes
{
    public class GetLongTermIncomesQuery : IRequest<ICollection<LongTermIncomeDto>>
    { }
}
