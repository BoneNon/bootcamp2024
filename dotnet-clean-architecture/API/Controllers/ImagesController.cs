using Application.Features.Image.Commands.UploadImage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase {
        private readonly IMediator mediator;

        public ImagesController(IMediator mediator) {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile file,
            [FromForm] string fileName, [FromForm] string title) {
            await mediator.Send(new UploadImageCommand { File = file, FileName = fileName, Title = title });

            return Ok();
        }
    }
}
