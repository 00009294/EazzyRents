using EazzyRents.Application.UseCases.Requests.Tenant.Commands;
using EazzyRents.Application.UseCases.Requests.Tenant.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EazzyRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantRequestController : ControllerBase
    {
        private readonly IMediator mediator;

        public TenantRequestController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await this.mediator.Send(new GetAllQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateCommand command)
        {
            return Ok(await this.mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            return Ok(await this.mediator.Send(new DeleteCommand(id)));
        }
    }
}
