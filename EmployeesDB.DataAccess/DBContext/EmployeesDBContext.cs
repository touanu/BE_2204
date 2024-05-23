using EmployeesDB.DataAccess.Objects;
using Microsoft.EntityFrameworkCore;

namespace EmployeesDB.DataAccess.DBContext
{
    public class EmployeesDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-DBAC4GV\\SQLEXPRESS;Initial Catalog=EmployeesDB;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True");
        }

        public virtual DbSet<Employeer> Employeers { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<ProcessDetail> ProcessDetails { get; set; }
    }
}
