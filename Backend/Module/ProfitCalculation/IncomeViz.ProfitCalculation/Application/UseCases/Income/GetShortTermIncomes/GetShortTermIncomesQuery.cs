using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Income.GetShortTermIncomes
{
    public class GetShortTermIncomesQuery : IRequest<ICollection<ShortTermIncomeDto>>
    {
        [Required] public Guid PredictionId { get; set; }
    }
}
