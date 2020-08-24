using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IncomeViz.ProfitCalculation.Application.UseCases.AddLongTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.AddShortTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.DeleteShortTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.DeleteLongTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.GetShortTermIncomes;
using IncomeViz.ProfitCalculation.Application.UseCases.GetLongTermIncomes;
using IncomeViz.ProfitCalculation.Application.UseCases.UpdateShortTermIncome;

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
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
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
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
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
        [Consumes("application/json")]
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
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
        [Consumes("application/json")]
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(DeleteLongTermIncomeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Returns a collection of short term incomes
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("short-term/all")]
        [Produces("application/json")] [Consumes("application/json")]
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromQuery] GetShortTermIncomesQuery query)
        {
            var shortTermIncomes = await _mediator.Send(query);
            return Ok(shortTermIncomes);
        }

        /// <summary>
        /// Returns a collection of long term incomes
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("long-term/all")]
        [Produces("application/json")] [Consumes("application/json")]
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromQuery] GetLongTermIncomesQuery query)
        {
            var longTermIncomes = await _mediator.Send(query);
            return Ok(longTermIncomes);
        }

        /// <summary>
        /// Updates short term income with specified id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("short-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
        public async Task<IActionResult> Update(UpdateShortTermIncomeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
