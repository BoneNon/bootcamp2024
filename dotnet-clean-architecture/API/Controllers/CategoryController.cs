using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetAllCategories;
using Application.Features.Category.Queries.GetCategoriesById;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator) {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto request)
        {
            var command = new CreateCategoryCommand()
            {
                Request = request
            };

            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllCategories() {
            var categories = await mediator.Send(new GetAllCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetByIdCategories([FromRoute] Guid id)
        {
            var command = new GetCategoriesByIdQuery()
            {
                Id = id
            };

            var result = await mediator.Send(command);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryRequestDto request) {

            var command = new UpdateCategoryCommand() {
                Request = request,
                Id = id
            };

            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id) {

            var command = new DeleteCategoryCommand() {
                Id = id
            };

            var result = await mediator.Send(command);
            if (result == null) {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("Count")]
        //[Authorize]
        public async Task<IActionResult> GetCountCategories()
        {
            var categories = await mediator.Send(new GetAllCategoriesQuery());
            
            return Ok("Count: " + categories.Count);
        }
    }
}
