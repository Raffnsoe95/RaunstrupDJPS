using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

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
    }
}
