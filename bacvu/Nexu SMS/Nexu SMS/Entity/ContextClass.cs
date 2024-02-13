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
        //public DbSet<Admin> admins { get; set; }
        public DbSet<AdmissionNo> admissionNos { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Users> users { get; set; }

        public DbSet<ClassManagement> classes { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<SAttendance> sattendances { get; set; }
        public DbSet<TAttendance> tattendances { get; set; }
        public DbSet<Exam> exams { get; set; }  
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Result> results { get; set; }
        
       // public DbSet<PublishResult> publishResults { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("conString"));
        }
        
    }
}
