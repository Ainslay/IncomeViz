using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IncomeViz.ProfitCalculation.Application.UseCases.AddLongTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.AddShortTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.DeleteShortTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.DeleteLongTermIncome;

namespace IncomeViz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IncomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Adds LongTermIncome entry to the database.
        /// </summary>
        /// <exception cref="System.NullReferenceException">Thrown when predictionId does not exist</exception>
        /// <exception cref="IncomeViz.BuildingBlocks.Exceptions.BusinessRuleValidationException">
        /// Thrown when provided data breaks any business rule</exception>
        /// <param name="command">Data provided in order to add LongTermIncome</param>
        /// <returns></returns>
        [HttpPost]
        [Route("long-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post(AddLongTermIncomeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Adds ShortTermIncome entry to the database.
        /// </summary>
        /// <exception cref="System.NullReferenceException">Thrown when predictionId does not exist</exception>
        /// <exception cref="IncomeViz.BuildingBlocks.Exceptions.BusinessRuleValidationException">
        /// Thrown when provided data breaks any business rule</exception>
        /// <param name="command">Data provided in order to add ShortTermIncome</param>
        /// <returns></returns>
        [HttpPost]
        [Route("short-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post(AddShortTermIncomeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Deletes short term income with specified id from database
        /// </summary>
        /// <exception cref="System.NullReferenceException">Thrown when there is no short term income with specified id</exception>
        /// <param name="command">Contains id of the short term income to remove</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("short-term")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(DeleteShortTermIncomeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Deletes long term income with specified id from database
        /// </summary>
        /// <exception cref="System.NullReferenceException">Thrown when there is no long term income with specified id</exception>
        /// <param name="command">Contains id of the long term income to remove</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("long-term")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(DeleteLongTermIncomeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
