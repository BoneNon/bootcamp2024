using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Queries.GetTokenJwt {
    public class GetTokenJwtQuery : IRequest<LoginResponseDto> {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
