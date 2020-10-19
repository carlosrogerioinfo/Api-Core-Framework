using InVivo.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVivo.Domain.Commands.Results
{
    public class RegisterExamLabCommandResult : ICommandResult
    {
        public RegisterExamLabCommandResult()
        {

        }

        public RegisterExamLabCommandResult(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
