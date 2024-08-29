using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Image.Commands.UploadImage {
    public class UploadImageCommand : IRequest<BlogImageDto> {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string Title { get; set; }
    }
}
