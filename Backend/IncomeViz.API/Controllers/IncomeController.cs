﻿using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IncomeViz.ProfitCalculation.Application.UseCases.AddLongTermIncome;
using IncomeViz.ProfitCalculation.Application.UseCases.AddShortTermIncome;

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

        [HttpPost]
        [Route("long-term")]
        public async Task<IActionResult> Post(AddLongTermIncomeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("short-term")]
        public async Task<IActionResult> Post(AddShortTermIncomeCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}