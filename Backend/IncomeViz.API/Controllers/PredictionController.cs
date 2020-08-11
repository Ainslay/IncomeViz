using System.Linq;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Application.UseCases.AddPrediction;
using IncomeViz.ProfitCalculation.Application.UseCases.GeneratePredictionByDateRange;
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

        [HttpPost]
        public async Task<IActionResult> Post(AddPredictionCommand command)
        {
            var predictionId = await _mediator.Send(command);
            return Ok(predictionId);
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
