using Application.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles {
    public class CategoryProfile : Profile {
        public CategoryProfile() {
            CreateMap<Category, CategoryDto>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id));
            CreateMap<CreateCategoryRequestDto, Category>();
            CreateMap<UpdateCategoryRequestDto, Category>();
        }
    }
}
