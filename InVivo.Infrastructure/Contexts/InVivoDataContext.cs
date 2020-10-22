using InVivo.Domain.Entities;
using InVivo.Infrastructure.Mappings;
using InVivo.Shared;
using System.Data.Entity;

namespace InVivo.Infrastructure.Contexts
{
    public class InVivoDataContext: DbContext
    {
        public InVivoDataContext():base(Runtime.ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }


        public DbSet<ExamLab> Exams { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ExamLabMap());
            modelBuilder.Configurations.Add(new UserMap());
        }

    }
}
