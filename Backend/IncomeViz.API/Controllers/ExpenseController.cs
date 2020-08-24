using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IncomeViz.ProfitCalculation.Application.UseCases.AddLongTermExpense;
using IncomeViz.ProfitCalculation.Application.UseCases.AddShortTermExpense;

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
    }
}
