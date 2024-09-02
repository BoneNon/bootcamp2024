using Application.Contracts.Persistence;
using Application.Features.Category.Commands.CreateCategory;
using Application.Models;
using Application.Profiles;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.test.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryHandlerTests
    {
        [Fact]
        public async void Handler_HappyFlow_CategoryShouldBeCreated()
        {
            var command = new CreateCategoryCommand()
            {
                Request = new CreateCategoryRequestDto()
                {
                    Name = "test Category",
                    UrlHandle = "test Category"
                }
            };
            var token = CancellationToken.None;
            var categoryRepository = new Mock<ICategoryRepository>();
            categoryRepository.Setup(it => it.CreateAsync(It.IsAny<Domain.Entities.Category>())).ReturnsAsync(new Domain.Entities.Category
            {
                Name = "Test",
                UrlHandle = "test-category",
                Id = Guid.NewGuid()
            });
            var mapper = new MapperConfiguration(config => config.AddProfile<CategoryProfile>()).CreateMapper();
            var handler = new CreateCategoryHandler(categoryRepository.Object, mapper);
            //Act
            var result = await handler.Handle(command, token);
            //Assert
            Assert.NotNull(result);
            Assert.Equal("Test", result.Name);
        }




    }
}
