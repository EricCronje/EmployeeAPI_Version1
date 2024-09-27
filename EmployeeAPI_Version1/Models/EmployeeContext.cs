using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI_Version1.Models
{
    /// <summary>
    /// Need the context class to query and save data
    /// </summary>
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Employee> employees { get; set; }
    }
}
