using Microsoft.EntityFrameworkCore;

namespace LeaveManagementAPI.Models
{
    public class LeaveContext : DbContext
    {
        public LeaveContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Leave> Leaves { get; set; }
    }
}
