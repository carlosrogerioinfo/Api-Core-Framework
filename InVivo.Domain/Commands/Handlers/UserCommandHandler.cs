using FluentValidator;
using InVivo.Domain.Commands.Inputs;
using InVivo.Domain.Commands.Results;
using InVivo.Domain.Entities;
using InVivo.Domain.Repositories;
using InVivo.Shared.Commands;

namespace InVivo.Domain.Commands.Handlers
{
    public class UserCommandHandler : Notifiable, ICommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _UserRepository;

        public UserCommandHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }


        public ICommandResult Handle(RegisterUserCommand command)
        {
            // 1. Criar instância do objeto
            var entity = new User(command.Username, command.Password, command.ConfirmPassword, command.Email);

            // 2. Adicionar notificações
            AddNotifications(entity.Notifications);

            // 3. Verificar se é válido (se existem notificações
            if (!IsValid())
                return null;

            // 4. Salva as alterações no EF
            _UserRepository.Save(entity);

            // 5. Retorna os dados que foram cadastrados
            return new RegisterUserCommandResult(entity.Id, entity.Username);

        }
    }
}
