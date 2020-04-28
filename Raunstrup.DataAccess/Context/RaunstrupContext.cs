using System;
using System.Collections.Generic;
using System.Text;
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

        public DbSet<Item> Items { get; set; }

    }
}
