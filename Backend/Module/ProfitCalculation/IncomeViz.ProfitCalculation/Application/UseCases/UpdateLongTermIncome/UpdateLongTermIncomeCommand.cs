using System;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Funds;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.UpdateLongTermIncome
{
    public class UpdateLongTermIncomeCommand : IRequest
    {
        [Required] public Guid LongTermIncomeId { get; set; }
        [Required(AllowEmptyStrings = false)] public string Name { get; set; }
        [Required] public int ExecutionDay { get; set; }
        [Required] public decimal Amount { get; set; }
        [Required] public Currency Currency { get; set; }
        [Required] public DateTime StartingDate { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}
