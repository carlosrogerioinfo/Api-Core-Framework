using InVivo.Shared.Commands;
using System;

namespace InVivo.Domain.Commands.Inputs
{
    public class RegisterUserCommand : ICommand
    {
        //public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }

    }
}
