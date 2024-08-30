using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPost.Commands.UpdateBlogPost
{
    public class UpdateBlogPostCommand : IRequest<BlogPostDto>
    {
        public UpdateBlogPostRequestDto Request { get; set; }
        public Guid Id { get; set; }
    }
}
