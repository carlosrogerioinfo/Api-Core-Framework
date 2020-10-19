using FluentValidator;
using InVivo.Domain.Commands.Inputs;
using InVivo.Domain.Commands.Results;
using InVivo.Domain.Entities;
using InVivo.Domain.Repositories;
using InVivo.Shared.Commands;

namespace InVivo.Domain.Commands.Handlers
{
    public class ExamLabCommandHandler : Notifiable, ICommandHandler<RegisterExamLabCommand>
    {
        private readonly IExamLabRepository _examlabRepository;

        public ExamLabCommandHandler(IExamLabRepository examlabRepository)
        {
            _examlabRepository = examlabRepository;
        }


        public ICommandResult Handle(RegisterExamLabCommand command)
        {
            // 1. Criar instância do objeto
            var exam = new ExamLab(command.Code, command.Name);

            // 2. Adicionar notificações
            AddNotifications(exam.Notifications);

            // 3. Verificar se é válido (se existem notificações
            if (!IsValid())
                return null;

            // 4. Salva as alterações no EF
            _examlabRepository.Save(exam);

            // 5. Retorna os dados que foram cadastrados
            return new RegisterExamLabCommandResult(exam.Id, exam.Name);

        }
    }
}
