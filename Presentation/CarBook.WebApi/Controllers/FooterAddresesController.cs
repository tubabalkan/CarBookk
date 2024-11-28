using CarBook.Application.Features.Mediator.Commands.FeatureCommands;
using CarBook.Application.Features.Mediator.Commands.FooterAddressCommands;
using CarBook.Application.Features.Mediator.Queries.FeatureQueries;
using CarBook.Application.Features.Mediator.Queries.FooterAddresQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddresesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddresesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FooterAddresList()
        {
            var values = await _mediator.Send(new GetFooterAddresQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddres(int id)
        {
            var value = await _mediator.Send(new GetFooterAddresByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddres(CreateFooterAddresCommand command)
        {
            await _mediator.Send(command);
            return Ok("Adres Başarıyla Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFooterAddres(int id)
        {
            await _mediator.Send(new RemoveFooterAddresCommand(id));
            return Ok("Adres Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddres(UpdateFooterAddresCommand command)
        {
            await _mediator.Send(command);
            return Ok("Adres Başarıyla Güncellendi");
        }

    }
}
