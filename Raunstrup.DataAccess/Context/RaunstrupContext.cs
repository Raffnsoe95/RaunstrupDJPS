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

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<WorkingHours> WorkingHours { get; set; }

        public DbSet<Customer> customers { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectDriving> projectDrivings { get; set; }

        public DbSet<ProjectEmployee> ProjectEmployees { get; set; }

        public DbSet<ProjectItem> ProjectItems { get; set; }

    }
}
