using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.UpdateCategory {
    public class UpdateCategoryCommand : IRequest<CategoryDto> {
        public UpdateCategoryRequestDto Request { get; set; }
        public Guid Id { get; set; }
    }
}
