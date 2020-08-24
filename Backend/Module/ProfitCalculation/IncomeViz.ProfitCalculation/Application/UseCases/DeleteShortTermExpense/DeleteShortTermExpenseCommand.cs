using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.DeleteShortTermExpense
{
    public class DeleteShortTermExpenseCommand : IRequest
    {
        [Required] public Guid ShortTermExpenseId { get; set; }
    }
}
