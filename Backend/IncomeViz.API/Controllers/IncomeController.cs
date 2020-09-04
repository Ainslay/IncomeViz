using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Application.UseCases.Income.AddLongTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.Income.AddShortTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.Income.DeleteLongTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.Income.DeleteShortTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.Income.GetLongTermIncomes;
using IncomeViz.ProfitCalculation.Application.UseCases.Income.GetShortTermIncomes;
using IncomeViz.ProfitCalculation.Application.UseCases.Income.UpdateLongTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.Income.UpdateShortTermIncome;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        /// <param name="id">Contains id of the short term income to remove</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("short-term/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteShortTermIncome(Guid id)
        {
            var command = new DeleteShortTermIncomeCommand {ShortTermIncomeId = id};
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Deletes long term income with specified id from database
        /// </summary>
        /// <param name="id">Contains id of the long term income to remove</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("long-term/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteLongTermIncome(Guid id)
        {
            var command = new DeleteLongTermIncomeCommand {LongTermIncomeId = id};
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Returns a collection of short term incomes
        /// </summary>
        /// <param name="predictionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("short-term/all/{predictionId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ICollection<ShortTermIncomeDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetShortTermIncomes(Guid predictionId)
        {
            var query = new GetShortTermIncomesQuery() { PredictionId = predictionId};
            var shortTermIncomes = await _mediator.Send(query);
            return Ok(shortTermIncomes);
        }

        /// <summary>
        /// Returns a collection of long term incomes
        /// </summary>
        /// <param name="predictionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("long-term/all/{predictionId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ICollection<LongTermIncomeDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetLongTermIncomes(Guid predictionId)
        {
            var query = new GetLongTermIncomesQuery() {PredictionId = predictionId};
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
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update(UpdateShortTermIncomeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Updates long term income with specified id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("long-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update(UpdateLongTermIncomeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
