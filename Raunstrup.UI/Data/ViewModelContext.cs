using Microsoft.EntityFrameworkCore;
using Raunstrup.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Raunstrup.DataAccess.Model;

namespace Raunstrup.UI.Data
{
    public class ViewModelContext : DbContext
    {
        public ViewModelContext()
        {

        }
        public ViewModelContext(DbContextOptions<ViewModelContext> options) : base(options)
        {

        }

        public DbSet<EmployeeViewModel> Employees { get; set; }

        public DbSet<ItemViewModel> Items { get; set; }

        public DbSet<CustomerViewModel> customers { get; set; }

        public DbSet<ProjectViewModel> Projects { get; set; }

        public DbSet<ProjectDrivingViewModel> projectDrivings { get; set; }

        public DbSet<WorkingHoursViewModel> WorkingHours { get; set; }

        public DbSet<Raunstrup.DataAccess.Model.WorkingHours> WorkingHours_1 { get; set; }

        public DbSet<Raunstrup.DataAccess.Model.CustomerDiscountType> CustomerDiscountTypes { get; set; }
    }
}

