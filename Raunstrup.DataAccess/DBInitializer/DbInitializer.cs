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
              //  Look for any customers.
                if (context.Customer.Any())
                    {
                        return;   // DB has been seeded
                    }

                context.Customer.AddRange(
                    new Customer
                    {
                       Name = "Hans Hansen",
                        Phone="12345678",
                        Address="Hansvej 1, 1111 Hansby",
                        Email="Hans@gmail.com",
                        Active=true
                    },


                    new Customer
                    {
                        Name = "Ole Olsen",
                        Phone = "87654321",
                        Address = "Olevej 2, 2222 Oleby",
                        Email = "Ole@gmail.com",
                        Active = true
                    },
                     new Customer
                     {
                         Name = "Bent Bentsen",
                         Phone = "12121212",
                         Address = "Bentvej 3, 3333 Bentby",
                         Email = "Bent@gmail.com",
                         Active = true
                     },
                      new Customer
                      {
                          Name = "Erik Eriksen",
                          Phone = "141414141",
                          Address = "Erikvej 4, 4444 Erikeby",
                          Email = "Erik@gmail.com",
                          Active = true
                      },
                       new Customer
                       {
                           Name = "Knud Knudsen",
                           Phone = "565656565",
                           Address = "Knudvej 5, 5555 Knudby",
                           Email = "Knud@gmail.com",
                           Active = true
                       }
                );
                context.SaveChanges();
            }
        }
    }
}
