using System.Linq;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Application.UseCases.AddPrediction;
using IncomeViz.ProfitCalculation.Application.UseCases.GetPrediction;
using IncomeViz.ProfitCalculation.Application.UseCases.GeneratePredictionByDateRange;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using IncomeViz.ProfitCalculation.Application.UseCases.GetShortPredictions;
using IncomeViz.ProfitCalculation.Application.UseCases.DeletePrediction;
using IncomeViz.ProfitCalculation.Application.UseCases.GetFullPrediction;

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

        [HttpPost]
        public async Task<IActionResult> Post(AddPredictionCommand command)
        {
            var predictionId = await _mediator.Send(command);
            return Ok(predictionId);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePredictionCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("short-prediction")]
        public async Task<IActionResult> Get([FromQuery]GetShortPredictionQuery query)
        {
            var prediction = await _mediator.Send(query);
            return Ok(prediction);
        }

        [HttpGet]
        [Route("short-prediction/all")]
        public async Task<IActionResult> Get([FromQuery]GetShortPredictionsQuery query)
        {
            var predictions = await _mediator.Send(query);
            return Ok(predictions);
        }

        /// <summary>
        /// Returns a full prediction containing all incomes and expenses
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("full-prediction")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromQuery] GetFullPredictionQuery query)
        {
            var prediction = await _mediator.Send(query);
            return Ok(prediction);
        }

        [HttpPost("generate")]
        [Produces("application/json")]
        public async Task<IActionResult> Post(GeneratePredictionByDateRangeQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result.Select(r => new
            {
                Name = r.Date.Date,
                Value = r.Money.GetAmount()
            }));
        }
    }
}
