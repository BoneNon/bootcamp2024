using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPost.Queries.GetBlogPostById
{
    public class GetBlogPostByIdQuery : IRequest<BlogPostDto>
    {
        public Guid Id { get; set; }
    }
}
