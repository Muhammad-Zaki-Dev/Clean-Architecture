using Application.Features.Categories.Command.Create;
using Application.Features.Categories.Command.Update;
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
    }
}
