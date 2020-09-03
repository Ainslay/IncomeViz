using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Application.UseCases.Prediction.AddPrediction;
using IncomeViz.ProfitCalculation.Application.UseCases.Prediction.DeletePrediction;
using IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GeneratePredictionByDateRange;
using IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GetPrediction;
using IncomeViz.ProfitCalculation.Application.UseCases.Prediction.GetShortPredictions;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IncomeViz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredictionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PredictionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Creates a new prediction entry in database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post(AddPredictionCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Deletes database entry of prediction with specified id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(DeletePredictionCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Returns a short prediction with specified id
        /// </summary>
        /// <param name="predictionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PredictionDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(Guid predictionId)
        {
            var query = new GetPredictionQuery {Id = predictionId};
            var prediction = await _mediator.Send(query);
            return Ok(prediction);
        }

        /// <summary>
        /// Returns a collection of short predictions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/all")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ICollection<PredictionDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            var predictions = await _mediator.Send(new GetPredictionsQuery());
            return Ok(predictions);
        }

        /// <summary>
        /// Generates prediction data based on starting date and prediction type
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("generate")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post(GeneratePredictionByDateRangeQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result.Select(r => new {Name = r.Date.Date, Value = r.Money.GetAmount()}));
        }
    }
}
