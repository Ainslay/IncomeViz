using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace IncomeViz.ProfitCalculation.Application.UseCases.Prediction.DeletePrediction
{
    public class DeletePredictionCommand : IRequest
    {
        [Required] public Guid Id { get; set; }
    }
}
