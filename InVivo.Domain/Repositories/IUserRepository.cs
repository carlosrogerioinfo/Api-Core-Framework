using InVivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVivo.Domain.Repositories
{
    public interface IUserRepository
    {
        User GetById(Guid id);

        User GetByUser(string email, string password);

        void Save(User user);

        void Update(User user);

    }
}
