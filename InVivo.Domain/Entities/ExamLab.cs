using FluentValidator;
using InVivo.Shared.Entities;

namespace InVivo.Domain.Entities
{
    public class ExamLab: Entity
    {

        //Constructors
        protected ExamLab() { } 

        public ExamLab(string code, string name)
        {
            Code = code;
            Name = name;
            Deactivate();

            // Validação /Notificação
            new ValidationContract<ExamLab>(this)
                .IsRequired(x => x.Code, "Código é requerido")
                .IsRequired(x=>x.Name, "Nome é requerido");


        }

        //Properties
        public string Code { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }

        //Methods
        public void Activate() => Active = true;
        public void Deactivate() => Active = false;
    }
}
