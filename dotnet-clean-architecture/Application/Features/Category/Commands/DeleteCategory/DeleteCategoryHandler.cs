using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.DeleteCategory {
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, CategoryDto> {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper) {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken) {
            var result = await categoryRepository.DeleteAsync(request.Id);

            return mapper.Map<CategoryDto>(result);
        }
    }
}
