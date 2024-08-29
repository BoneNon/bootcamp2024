using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles {
    public class BlogPostProfile : Profile {
        public BlogPostProfile() {
            CreateMap<CreateBlogPostRequestDto, BlogPost>()
                .ForMember(des => des.Categories, opt => opt.MapFrom(src => new List<Category>()));
            CreateMap<BlogPost, BlogPostDto>();
        }
    }
}
