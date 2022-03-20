using Microsoft.EntityFrameworkCore;
using WebAppApi.Models;

namespace WebAppApi.DbContexts
{
    public class WebAppDbContext : DbContext
    {
        public WebAppDbContext(DbContextOptions<WebAppDbContext> options) :
            base(options)
        {
        }

        public DbSet<Employee>? Employees { get; set; }
    }
}