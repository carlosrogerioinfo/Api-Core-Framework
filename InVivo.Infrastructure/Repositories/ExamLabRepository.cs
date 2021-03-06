﻿using InVivo.Domain.Entities;
using InVivo.Domain.Repositories;
using InVivo.Infrastructure.Contexts;
using System;
using System.Data.Entity;
using System.Linq;

namespace InVivo.Infrastructure.Repositories
{
    public class ExamLabRepository : IExamLabRepository
    {
        private readonly InVivoDataContext _context;

        public ExamLabRepository(InVivoDataContext context)
        {
            _context = context;
        }

        public ExamLab GetByCode(string code)
        {
            return _context
                .Exams
                .AsNoTracking() //For increase performance
                .FirstOrDefault (x => x.Code.Equals(code));
        }

        public ExamLab GetById(Guid id)
        {
            return _context
                .Exams
                .AsNoTracking() //For increase performance
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Save(ExamLab examlab)
        {
            _context.Exams.Add(examlab);
        }

        public void Update(ExamLab examlab)
        {
            _context.Entry(examlab).State = EntityState.Modified;
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
