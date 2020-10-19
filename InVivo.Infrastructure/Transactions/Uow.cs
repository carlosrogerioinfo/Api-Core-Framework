using InVivo.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVivo.Infrastructure.Transactions
{
    public class Uow : IUow
    {

        private readonly InVivoDataContext _context;

        public Uow(InVivoDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            // Do Nothing
        }

    }
}
