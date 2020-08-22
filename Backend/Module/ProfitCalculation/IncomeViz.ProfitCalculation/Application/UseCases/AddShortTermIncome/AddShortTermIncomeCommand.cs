using System;
using MediatR;
using JetBrains.Annotations;
using System.ComponentModel.DataAnnotations;
using IncomeViz.ProfitCalculation.Domain.Funds;

namespace IncomeViz.ProfitCalculation.Application.UseCases.AddShortTermIncome
{
    public class AddShortTermIncomeCommand : IRequest
    {
        [Required] public Guid PredictionId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [NotNull]
        public string Name { get; set; }

        [Required] public DateTime ExecutionDate { get; set; }

        [Required] public decimal Amount { get; set; }

        [Required] public Currency Currency { get; set; }
    }
}
