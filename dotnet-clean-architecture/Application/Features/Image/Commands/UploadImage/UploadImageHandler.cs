using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Image.Commands.UploadImage {

    public class UploadImageHandler : IRequestHandler<UploadImageCommand, BlogImageDto> {

        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IBlogImageRepository blogImageRepository;
        private readonly IMapper mapper;

        public UploadImageHandler(IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor, IBlogImageRepository blogImageRepository, IMapper mapper) {
            this.hostingEnvironment = hostingEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.blogImageRepository = blogImageRepository;
            this.mapper = mapper;
        }

        public async Task<BlogImageDto> Handle(UploadImageCommand request, CancellationToken cancellationToken) {
            var file = request.File;
            var fileExtension = Path.GetExtension(file.FileName).ToLower();

            Directory.CreateDirectory(Path.Combine(hostingEnvironment.ContentRootPath, "Images"));

            var localPath = Path.Combine(hostingEnvironment.ContentRootPath, "Images", $"{request.FileName}{fileExtension}");
            using var stream = new FileStream(localPath, FileMode.Create);
            await file.CopyToAsync(stream);

            //Update to database
            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlPath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{request.FileName}{fileExtension}";

            var blogImage = new BlogImage {
                FileName = request.FileName,
                Title = request.Title,
                FileExtension = fileExtension,
                Url = urlPath,
                DateCreated = DateTime.Now
            };

            var result = await blogImageRepository.SaveImage(blogImage);

            return mapper.Map<BlogImageDto>(result);
        }
    }
}
