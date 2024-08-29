using Application.Contracts.Persistence;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Category.Commands.CreateCategory {
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryDto> {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;


        public CreateCategoryHandler(ICategoryRepository categoryRepository, IMapper mapper) {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public async Task<CategoryDto> Handle(CreateCategoryCommand command, CancellationToken cancellationToken) {

            var categoryModel = mapper.Map<Domain.Entities.Category>(command.Request);
            var result = await categoryRepository.CreateAsync(categoryModel);

            return mapper.Map<CategoryDto>(result);
        }
    }
}
