﻿using Application.Features.Categories.Command;
using Application.Features.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;
        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("PostCategroy")]
        public async Task<IActionResult> PostCategroy([FromBody] CreateCategoryCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpPut("PutCategory")]
        public async Task<IActionResult> PutCategory([FromBody] UpdateCategoryCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await mediator.Send(new GetAllCategoriesQuery()));
        }
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {

            return Ok(await mediator.Send(new GetByIdCategoryQuery { Id = Id }));
        }
    }
}
