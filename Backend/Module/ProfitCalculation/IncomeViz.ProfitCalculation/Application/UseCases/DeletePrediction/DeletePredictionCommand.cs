using System;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace IncomeViz.ProfitCalculation.Application.UseCases.DeletePrediction
{
    public class DeletePredictionCommand : IRequest
    {
        [Required] public Guid Id { get; set; }
    }
}
