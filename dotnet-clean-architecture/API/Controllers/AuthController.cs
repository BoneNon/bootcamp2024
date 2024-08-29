using Application.Features.Auth.Queries.GetTokenJwt;
using Application.Features.Register.Commands.CreateAccount;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator) {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestDto registerModel) {
            var result = await mediator.Send(new CreateAccountCommand { RegisterModel = registerModel });
            return Ok(result);
        }

        [HttpPost("login")]
        public async  Task<IActionResult> Login([FromBody] LoginRequestDto request) {
            var result = await mediator.Send(new GetTokenJwtQuery { Email = request.Email, Password = request.Password });
            return Ok(result);
        }
    }
}
