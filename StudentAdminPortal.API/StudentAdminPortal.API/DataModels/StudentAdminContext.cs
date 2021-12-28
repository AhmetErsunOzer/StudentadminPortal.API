using Microsoft.EntityFrameworkCore;

namespace StudentAdminPortal.API.DataModels
{
    public class StudentAdminContext : DbContext
    {
        public StudentAdminContext(DbContextOptions<StudentAdminContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Adress> Adresses { get; set; }
    }
}
