using InVivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVivo.Domain.Repositories
{
    public interface IExamLabRepository
    {
        ExamLab GetById(Guid id);

        ExamLab GetByCode(string code);

        void Save(ExamLab examlab);

        void Update(ExamLab examlab);

    }
}
