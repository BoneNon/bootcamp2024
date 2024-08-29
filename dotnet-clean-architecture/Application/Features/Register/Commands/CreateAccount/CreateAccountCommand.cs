using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Register.Commands.CreateAccount {
    public class CreateAccountCommand : IRequest<bool> {
        public RegisterRequestDto RegisterModel {  get; set; }
    }
}
