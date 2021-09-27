using GG.Agro.Application.Commands.Contract;
using GG.Agro.Domain.Entities;
using GG.Agro.Infra.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GG.Agro.Api.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    public class ContractController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Contract>> GetAll([FromServices] IUnitOfWork unitOfWork)
            => await unitOfWork.Contracts.GetAll();

        [HttpPost]
        public async Task<IActionResult> Create(CreateContractCommand command, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);
            
            if (result.IsValid)
                return Ok();

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContractCommand command, [FromServices] IMediator mediator)
        {
            var result = await mediator.Send(command);

            if (result.IsValid)
                return Ok();

            return BadRequest(result);
        }
    }
}
