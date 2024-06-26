﻿using EazzyRents.Application.UseCases.Images.Commands;
using EazzyRents.Application.UseCases.Images.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EazzyRents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IMediator mediator;

        public ImageController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllImages()
        {
            return Ok(await this.mediator.Send(new GetAllQuery()));
        }

        [HttpGet]
        [Route("GetByRealestateId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await this.mediator.Send(new GetByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromQuery]CreateImageCommand createImageCommand)
        {
            return Ok(await this.mediator.Send(createImageCommand));
        }
    }
}
