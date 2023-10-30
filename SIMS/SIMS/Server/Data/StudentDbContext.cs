using Microsoft.EntityFrameworkCore;
using SIMS.Shared;

namespace SIMS.Server.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public DbSet<Department> Departments { get; set; }

    }
}
