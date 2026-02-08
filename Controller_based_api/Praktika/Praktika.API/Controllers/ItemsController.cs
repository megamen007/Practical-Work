using MediatR;
using Microsoft.AspNetCore.Mvc;
using Praktika.Application.Items.Commands.CreateItem;
using Praktika.Application.Items.DTOs;
using Praktika.Application.Items.Queries.GetAllItems;
using Praktika.Application.Items.Queries.GetItemById;

namespace Praktika.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllItems([FromQuery] int? categoryId = null)
        {
            var query = new GetAllItemsQuery(categoryId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetItem(int id)
        {
            var query = new GetItemByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateItem([FromForm] CreateItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}