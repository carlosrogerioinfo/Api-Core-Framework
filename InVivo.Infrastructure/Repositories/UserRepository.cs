using InVivo.Domain.Entities;
using InVivo.Domain.Repositories;
using InVivo.Infrastructure.Contexts;
using System;
using System.Data.Entity;
using System.Linq;

namespace InVivo.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InVivoDataContext _context;

        public UserRepository(InVivoDataContext context)
        {
            _context = context;
        }

        public User GetById(Guid id)
        {
            return _context
                .Users
                .AsNoTracking() //For increase performance
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public User GetByUser(string email, string password)
        {
            return _context
                .Users
                .AsNoTracking() //For increase performance
                .FirstOrDefault(x => x.Email.Equals(email) 
                    && x.Password.Equals(password));
        }

        public void Save(User User)
        {
            _context.Users.Add(User);
        }

        public void Update(User User)
        {
            _context.Entry(User).State = EntityState.Modified;
        }


        /*
         
            Exists
            public bool DocumentExists(string document)
            {
                return _context.Customers.Any(x => x.Document.Number == document);
            }
         
         
         */
    }
}
