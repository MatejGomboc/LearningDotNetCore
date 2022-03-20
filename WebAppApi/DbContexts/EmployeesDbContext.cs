using Microsoft.EntityFrameworkCore;
using WebAppApi.Models;

namespace WebAppApi.DbContexts
{
    public class EmployeesDbContext : DbContext
    {
        public EmployeesDbContext(DbContextOptions<EmployeesDbContext> options) :
            base(options)
        {
        }

        public DbSet<Employee>? Employees { get; set; }
    }
}