using InVivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVivo.Infrastructure.Mappings
{
    public class ExamLabMap: EntityTypeConfiguration<ExamLab>
    {
        public ExamLabMap()
        {

            ToTable("biositeapp_exams");
            HasKey(x => x.Id);

            Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(5);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(x => x.Active)
                .IsRequired();

        }
    }
}