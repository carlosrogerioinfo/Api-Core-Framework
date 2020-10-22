using InVivo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InVivo.Infrastructure.Mappings
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {

            ToTable("biositeapp_user");
            HasKey(x => x.Id);

            Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.Active)
                .IsRequired();

        }
    }
}