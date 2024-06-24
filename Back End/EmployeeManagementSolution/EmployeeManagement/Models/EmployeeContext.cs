using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasIndex(e => new { e.LicenseNumber, e.PassportNumber })
                .IsUnique(true);
            modelBuilder.Entity<User>()
                .HasIndex(u => new { u.PasswordHash, u.PasswordKey })
                .IsUnique(true);
        }
    }
}
