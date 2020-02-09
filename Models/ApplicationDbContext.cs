using System.Data.Entity;

namespace SeatingChart.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ApplicationDbContext> Employees{ get; set; }
    }
}