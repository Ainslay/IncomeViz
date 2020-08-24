using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IncomeViz.ProfitCalculation.Application.UseCases.AddLongTermExpense;
using IncomeViz.ProfitCalculation.Application.UseCases.AddShortTermExpense;
using IncomeViz.ProfitCalculation.Application.UseCases.GetLongTermExpenses;
using IncomeViz.ProfitCalculation.Application.UseCases.GetShortTermExpenses;

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
        /// Adds LongTermExpense entry to the database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("long-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
        public async Task<IActionResult> Post(AddLongTermExpenseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Adds ShortTermExpense entry to the database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("short-term")]
        [Consumes("application/json")]
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
        public async Task<IActionResult> Post(AddShortTermExpenseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        /// <summary>
        /// Returns a collection of short term expenses
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("short-term")]
        [Consumes("application/json")]
        [Produces("application/json")] 
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromQuery] GetShortTermExpensesQuery query)
        {
            var shortTermExpenses = await _mediator.Send(query);
            return Ok(shortTermExpenses);
        }

        /// <summary>
        /// Returns a collection of short term expenses
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("long-term")]
        [Consumes("application/json")]
        [Produces("application/json")] 
        [ProducesResponseType(200)] [ProducesResponseType(400)] [ProducesResponseType(500)]
        public async Task<IActionResult> Get([FromQuery] GetLongTermExpensesQuery query)
        {
            var longTermExpenses = await _mediator.Send(query);
            return Ok(longTermExpenses);
        }
    }
}
