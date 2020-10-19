using InVivo.Shared.Commands;
using System;

namespace InVivo.Domain.Commands.Inputs
{
    public class RegisterExamLabCommand : ICommand
    {
        
        public string Code { get; set; }
        public string Name { get; set; }
        
    }
}
