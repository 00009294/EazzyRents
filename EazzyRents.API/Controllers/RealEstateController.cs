using EazzyRents.Application.UseCases.RealEstates.Commands;
using EazzyRents.Application.UseCases.RealEstates.Queries;
using EazzyRents.Core.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EazzyRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IMediator mediatr;

        public RealEstateController(IMediator mediatr)
        {
            this.mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.mediatr.Send(new GetAllQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateCommand command)
        {
            return Ok(await this.mediatr.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateCommand command)
        {
            return Ok(await this.mediatr.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            return Ok(await this.mediatr.Send(new DeleteCommand(id)));
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await this.mediatr.Send(new GetByIdQuery(id)));
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            return Ok(await this.mediatr.Send(new GetByNameQuery(name)));
        }

        [HttpGet]
        [Route("GetByEmail/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            return Ok(await this.mediatr.Send(new GetByEmailQuery(email)));
        }

        [HttpGet]
        [Route("GetByAddress/{address}")]
        public async Task<IActionResult> GetByAddress(Address address)
        {
            return Ok(await this.mediatr.Send(new GetByAddressQuery(address)));
        }

        [HttpGet]
        [Route("GetByPrice")]
        public async Task<IActionResult> GetByPrice(double fromPrice, double toPrice)
        {
            return Ok(await this.mediatr.Send(new GetByPriceQuery(fromPrice, toPrice)));
        }
    }
}
