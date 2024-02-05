using Microsoft.EntityFrameworkCore;
using Nexu_SMS.Repository;

namespace Nexu_SMS.Entity
{
    public class ContextClass: DbContext
    {
        public IConfiguration configuration;
        public ContextClass (IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<AdmissionNo> admissionNos { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Users> users { get; set; }

        public DbSet<ClassModel> classModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("conString"));
        }

    }
}
