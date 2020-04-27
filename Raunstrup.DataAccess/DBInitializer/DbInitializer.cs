using System;
using System.Collections.Generic;
using System.Text;
using Raunstrup.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Raunstrup.DataAccess.DBInitializer
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RaunstrupContext(serviceProvider.GetRequiredService<DbContextOptions<RaunstrupContext>>()))
            {
                context.Database.EnsureCreated();
                // Look for any movies.
                //if (context.Customer.Any())
                //{
                //    return;   // DB has been seeded
                //}

                //context.Customer.AddRange(
                //    new Customer
                //    {
                //        Title = "When Harry Met Sally",
                //        ReleaseDate = DateTime.Parse("1989-2-12"),
                //        Genre = "Romantic Comedy",
                //        Price = 7.99M,
                //        Rating = "R"
                //    },


                //    new Movie
                //    {
                //        Title = "Ghostbusters ",
                //        ReleaseDate = DateTime.Parse("1984-3-13"),
                //        Genre = "Comedy",
                //        Price = 8.99M,
                //        Rating = "G"
                //    }
                //);
                context.SaveChanges();
            }
        }
    }
}
