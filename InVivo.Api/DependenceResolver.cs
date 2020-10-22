using InVivo.Domain.Commands.Handlers;
using InVivo.Domain.Repositories;
using InVivo.Infrastructure.Contexts;
using InVivo.Infrastructure.Repositories;
using InVivo.Infrastructure.Transactions;
using Microsoft.Extensions.DependencyInjection;

namespace InVivo.Api
{
    public static class DependenceResolver
    {

        public static void Register(IServiceCollection services)
        {

            services.AddScoped<InVivoDataContext, InVivoDataContext>();
            services.AddTransient<IUow, Uow>();

            services.AddTransient<IExamLabRepository, ExamLabRepository>();
            services.AddTransient<ExamLabCommandHandler, ExamLabCommandHandler>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<UserCommandHandler, UserCommandHandler>();
                

        }

    }
}
