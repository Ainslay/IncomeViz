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

        [HttpPost]
        [Route("long-term")]
        public async Task<IActionResult> Post(AddLongTermExpenseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("short-term")]
        public async Task<IActionResult> Post(AddShortTermExpenseCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
