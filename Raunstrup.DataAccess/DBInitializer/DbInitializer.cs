using System;
using System.Collections.Generic;
using System.Text;
using Raunstrup.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Raunstrup.DataAccess.Model;

namespace Raunstrup.DataAccess.DBInitializer
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RaunstrupContext(serviceProvider.GetRequiredService<DbContextOptions<RaunstrupContext>>()))
            {
                context.Database.EnsureCreated();
                //Look for any movies.
                if (context.Items.Any())
                    {
                        return;   // DB has been seeded
                    }

                context.Items.AddRange(
                    new Item
                    {
                        Name = "Træ",
                        Price = 7.99M,
                        Active = true,
                    },
                    new Item
                    {
                        Name = "Vindu",
                        Price = 7.99M,
                        Active = true,
                    },
                    new Item
                    {
                        Name = "Søm",
                        Price = 7.99M,
                        Active = true,
                    },
                    new Item
                    {
                        Name = "Skruger",
                        Price = 7.99M,
                        Active = true,
                    },
                    new Item
                    {
                        Name = "Isolering",
                        Price = 7.99M,
                        Active = true,
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
