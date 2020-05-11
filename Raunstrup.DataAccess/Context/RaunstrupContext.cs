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

        //protected override void OnModelCreating(ModelBuilder modelBuilder) 
        //{
        //    modelBuilder.Entity<Project>().HasMany(c => c.UsedItems).has

        //    //    .Map(m =>
        //    //{
        //    //    m.ToTable("ProjectItem");
        //    //    m.MapLeftKey("ProjectId");
        //    //    m.MapRightKey("ItemId");
        //    //}); ;
        //    //modelBuilder.Entity<ProjectItem>().HasMany(c => c.AssignedItems);
        //}

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<WorkingHours> WorkingHours { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectDriving> projectDrivings { get; set; }

        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<ProjectUsedItem> ProjectUsedItems { get; set; }

        public DbSet<ProjectAssignedItem> ProjectAssignedItems { get; set; }

        public DbSet<CustomerDiscountType> CustomerDiscountTypes { get; set; }

        //public DbSet<ItemDiscountType> Discount { get; set; }
        }
}
