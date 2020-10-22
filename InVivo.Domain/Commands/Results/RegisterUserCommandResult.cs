using InVivo.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVivo.Domain.Commands.Results
{
    public class RegisterUserCommandResult : ICommandResult
    {
        public RegisterUserCommandResult()
        {

        }

        public RegisterUserCommandResult(Guid id, string user)
        {
            Id = id;
            User = user;
        }

        public Guid Id { get; set; }
        public string User { get; set; }
    }
}
