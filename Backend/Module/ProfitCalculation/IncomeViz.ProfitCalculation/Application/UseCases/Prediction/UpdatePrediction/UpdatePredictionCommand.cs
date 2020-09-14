using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using IncomeViz.ProfitCalculation.Domain.Funds;
using JetBrains.Annotations;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction
{
    public class UpdatePredictionCommand : IRequest
    {
        [Required] public Guid Id { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        [NotNull]
        public string Name { get; set; }

        [Required] public decimal Amount { get; set; }
        [Required] public Currency Currency { get; set; }
        [Required] public DateTime StartingDate { get; set; }
    }
}
