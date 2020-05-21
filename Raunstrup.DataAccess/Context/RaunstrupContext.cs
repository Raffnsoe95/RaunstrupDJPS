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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
            .HasIndex(b => b.Email)
            .IsUnique();

            modelBuilder.Entity<Customer>()
            .HasIndex(p => p.Phone)
            .IsUnique();

            //  .HasName("AlternateKey_Email");
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<WorkingHours> WorkingHours { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectDriving> ProjectDrivings { get; set; }

        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        public DbSet<ProjectUsedItem> ProjectUsedItems { get; set; }

        public DbSet<ProjectAssignedItem> ProjectAssignedItems { get; set; }

        public DbSet<ItemDiscountType> ItemDiscountTypes { get; set; }

        public DbSet<CustomerDiscountType> CustomerDiscountTypes { get; set; }
    }


}
