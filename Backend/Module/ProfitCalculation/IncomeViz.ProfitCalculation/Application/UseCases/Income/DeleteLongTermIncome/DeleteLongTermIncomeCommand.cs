using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Income.DeleteLongTermIncome
{
    public class DeleteLongTermIncomeCommand : IRequest
    {
        [Required] public Guid LongTermIncomeId { get; set; }
    }
}
