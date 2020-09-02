using System;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Funds;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Income.UpdateShortTermIncome
{
    public class UpdateShortTermIncomeCommand : IRequest
    {
        [Required] public Guid ShortTermIncomeId { get; set; }
        [Required(AllowEmptyStrings = false)] public string Name { get; set; }
        [Required] public DateTime ExecutionDate { get; set; }
        [Required] public decimal Amount { get; set; }
        [Required] public Currency Currency { get; set; }
    }
}
