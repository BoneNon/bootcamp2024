using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.CreateCategory {
    public class CreateCategoryCommand : IRequest<CategoryDto> {
        public CreateCategoryRequestDto Request { get; set; }
    }
}
