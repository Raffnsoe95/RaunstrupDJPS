using Microsoft.EntityFrameworkCore;
using Raunstrup.DataAccess.Model;

namespace Raunstrup.DataAccess.Context
{
    public class RaunstrupContext : DbContext
    {
        public RaunstrupContext()
        {

        }
        public RaunstrupContext(DbContextOptions<RaunstrupContext> options) : base(options)
        {

        }

        //public DbSet<Customer> Movie { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Customer> customers { get; set; }
    }
}
