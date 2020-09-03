using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Income.GetLongTermIncomes
{
    public class GetLongTermIncomesQuery : IRequest<ICollection<LongTermIncomeDto>>
    {
        [Required] public Guid PredictionId { get; set; }
    }
}
