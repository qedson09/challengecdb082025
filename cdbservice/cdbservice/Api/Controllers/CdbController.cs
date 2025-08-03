using cdbservice.Api;
using cdbservice.Core.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cdbservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CdbController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost("calcular")]
        public async Task<IActionResult> Calcular([FromBody] CalcularCdbPosFixadoCommand command)
        {
            var resultado = await _mediator.Send(command);
            return Ok(resultado);
        }
    }
}
