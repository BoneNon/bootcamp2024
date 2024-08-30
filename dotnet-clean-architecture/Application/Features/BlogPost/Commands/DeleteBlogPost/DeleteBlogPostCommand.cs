using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPost.Commands.DeleteBlogPost
{
    public class DeleteBlogPostCommand : IRequest<BlogPostDto>
    {
        public Guid Id { get; set; }
    }
}
