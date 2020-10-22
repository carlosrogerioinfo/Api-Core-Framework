using InVivo.Shared.Commands;

namespace InVivo.Domain.Commands.Inputs
{
    public class AuthenticateUserCommand : ICommand
    {
        //public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
