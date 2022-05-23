using As.Posterr.Application.Contracts.Posts;
using As.Posterr.Application.Contracts.Profiles;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace As.Posterr.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PostResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("following")]
        public async Task<IActionResult> Get([FromQuery] int index)
        {
            var result = await _mediator.SendAsync<List<PostResponse>> (new GetPostsRequest { All = false, Index = index });
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PostResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("all")]
        public async Task<IActionResult> GetAll([FromQuery] int index)
        {
            var result = await _mediator.SendAsync<List<PostResponse>>(new GetPostsRequest { All = true, Index = index });
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] PostRequest request)
        {
            await _mediator.PublishAsync(request);
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PostResponse>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("search")]
        public async Task<IActionResult> Search([FromQuery] string text, [FromQuery] int index)
        {
            var result = await _mediator.SendAsync<List<PostResponse>>(new GetSearchPostRequest { Text = text, Index = index });
            return Ok(result);
        }
    }
}
