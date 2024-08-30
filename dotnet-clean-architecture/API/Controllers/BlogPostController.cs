using Application.Features.BlogPost.Commands;
using Application.Features.BlogPost.Commands.CreateBlogPost;
using Application.Features.BlogPost.Queries.GetAllBlogPosts;
using Application.Features.BlogPost.Commands.DeleteBlogPost;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Features.BlogPost.Commands.UpdateBlogPost;
using Application.Features.BlogPost.Queries.GetBlogPostById;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase {
        private readonly IMediator mediator;

        public BlogPostController(IMediator mediator) {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreateBlogPostRequestDto request)
        {
            var command = new CreateBlogPostCommand { Request = request };
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts() {
            var result = await mediator.Send(new GetAllBlogPostsQuery());
            return Ok(result);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetBlogPostById([FromRoute] Guid id)
        {
            var command = new GetBlogPostByIdQuery()
            {
                Id = id
            };

            var result = await mediator.Send(command);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateBlogPost([FromRoute] Guid id, [FromBody] UpdateBlogPostRequestDto request)
        {

            var command = new UpdateBlogPostCommand()
            {
                Request = request,
                Id = id
            };

            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteBlogpost([FromRoute] Guid id)
        {

            var command = new DeleteBlogPostCommand()
            {
                Id = id
            };

            var result = await mediator.Send(command);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
