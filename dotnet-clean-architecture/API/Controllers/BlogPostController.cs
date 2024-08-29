using Application.Features.BlogPost.Commands;
using Application.Features.BlogPost.Queries.GetAllBlogPosts;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase {
        private readonly IMediator mediator;

        public BlogPostController(IMediator mediator) {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreateBlogPostRequestDto request) {
            var command = new CreateBlogPostCommand { Request = request };
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts() {
            var result = await mediator.Send(new GetAllBlogPostsQuery());
            return Ok(result);
        }
    }
}
