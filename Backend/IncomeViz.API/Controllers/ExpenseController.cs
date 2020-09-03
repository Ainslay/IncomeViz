using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IncomeViz.ProfitCalculation.Application.UseCases.Expense.AddLongTermExpense;
using IncomeViz.ProfitCalculation.Application.UseCases.Expense.AddShortTermExpense;
using IncomeViz.ProfitCalculation.Application.UseCases.Expense.DeleteLongTermExpense;
using IncomeViz.ProfitCalculation.Application.UseCases.Expense.DeleteShortTermExpense;
using IncomeViz.ProfitCalculation.Application.UseCases.Expense.GetLongTermExpenses;
using IncomeViz.ProfitCalculation.Application.UseCases.Expense.GetShortTermExpenses;
using IncomeViz.ProfitCalculation.Application.UseCases.Expense.UpdateLongTermExpense;
using IncomeViz.ProfitCalculation.Application.UseCases.Expense.UpdateShortTermExpense;
using IncomeViz.ProfitCalculation.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IncomeViz.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExpenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        ///     Adds LongTermExpense entry to the database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("long-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post(AddLongTermExpenseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        ///     Adds ShortTermExpense entry to the database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("short-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post(AddShortTermExpenseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        ///     Returns a collection of short term expenses
        /// </summary>
        /// <param name="predictionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("short-term/all")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ICollection<ShortTermExpenseDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetShortTermExpenses(Guid predictionId)
        {
            var query = new GetShortTermExpensesQuery() { PredictionId = predictionId};
            var shortTermExpenses = await _mediator.Send(query);
            return Ok(shortTermExpenses);
        }

        /// <summary>
        ///     Returns a collection of short term expenses
        /// </summary>
        /// <param name="predictionId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("long-term/all")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ICollection<LongTermExpenseDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetLongTermExpenses(Guid predictionId)
        {
            var query = new GetLongTermExpensesQuery() {PredictionId = predictionId};
            var longTermExpenses = await _mediator.Send(query);
            return Ok(longTermExpenses);
        }

        /// <summary>
        ///     Updates short term expense with specified id using data
        ///     provided in the request
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("short-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update(UpdateShortTermExpenseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        ///     Updates long term expense with specified id using data
        ///     provided in the request
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("long-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update(UpdateLongTermExpenseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        ///     Deletes short term expense with specified id from database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("short-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(DeleteShortTermExpenseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        ///     Deletes long term expense with specified id from database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("long-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(DeleteLongTermExpenseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
