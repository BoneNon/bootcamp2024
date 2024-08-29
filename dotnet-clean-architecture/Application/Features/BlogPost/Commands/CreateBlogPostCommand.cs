using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BlogPost.Commands {
    public class CreateBlogPostCommand : IRequest<BlogPostDto> {
        public CreateBlogPostRequestDto Request {  get; set; }
    }
}
