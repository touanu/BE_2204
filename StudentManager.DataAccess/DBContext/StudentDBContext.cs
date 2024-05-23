using Microsoft.EntityFrameworkCore;
using StudentManager.DataAccess.Objects;

namespace StudentManager.DataAccess.DBContext
{
    public class StudentDBContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
