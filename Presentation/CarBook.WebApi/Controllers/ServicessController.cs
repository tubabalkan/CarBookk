using CarBook.Application.Features.Mediator.Commands.PricingCommands;
using CarBook.Application.Features.Mediator.Commands.ServiceCommands;
using CarBook.Application.Features.Mediator.Queries.PricingQueries;
using CarBook.Application.Features.Mediator.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicessController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicessController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> ServicesList()
        {
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServices(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateServices(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteServices(int id)
        {
            await _mediator.Send(new RemoveServiceCommand(id));
            return Ok("Servis Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateServices(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Servis Başarıyla Güncellendi");
        }
    }
}
