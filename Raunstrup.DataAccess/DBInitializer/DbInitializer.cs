using System;
using System.Collections.Generic;
using System.Text;
using Raunstrup.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Raunstrup.DataAccess.Model;
using Microsoft.EntityFrameworkCore.Internal;



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
                if (context.customers.Any())
                    {
                        return;   // DB has been seeded
                    }

                context.customers.AddRange(
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
                context.Employees.AddRange(
                    new Employee
                    {
                        Name = "Brian Nielsen",
                        Tlfnr = "67589342",
                        Active = true,
                    },
                    new Employee
                    {
                        Name = "Henrik Kofoed",
                        Tlfnr = "78652341",
                        Active = true,
                    },
                    new Employee
                    {
                        Name = "Thomas Troelsen",
                        Tlfnr = "+4534782311",
                        Active = true,
                    },
                    new Employee
                    {
                        Name = "Rasmus Paludan",
                        Tlfnr = "54672291",
                        Active = true,
                    },
                    new Employee
                    {
                        Name = "Flemming Leth",
                        Tlfnr = "23456789",
                        Active = true,
                    }
                );
                Employee emp1 = new Employee();
                WorkingHours  workingHours1 =new WorkingHours  { Amount = 3, HourlyPrice = 400 };
                var Workingóurlist =new List<WorkingHours>();

                Workingóurlist.Add(workingHours1);
                context.Projects.AddRange(
                    new Project
                    {


                        Active = true,
                        Description = "Nyt tag",
                        EndDate = new DateTime(2020, 5, 5),
                        IsAccepted = true,
                        IsDone = false,
                        IsFixedPrice = false,
                        Price = 0m,
                        StartDate = new DateTime(2020, 5, 4),
                        WorkingHours = Workingóurlist


                    },
                    new Project
                    {
                        Active = true,
                        Description = "Nyt tag",
                        EndDate = new DateTime(2020, 5, 5),
                        IsAccepted = true,
                        IsDone = false,
                        IsFixedPrice = false,
                        Price = 0m,
                        StartDate = new DateTime(2020, 5, 4)


                    }, new Project
                    {
                        Active = true,
                        Description = "Nyt tag",
                        EndDate = new DateTime(2020, 5, 5),
                        IsAccepted = true,
                        IsDone = false,
                        IsFixedPrice = false,
                        Price = 0m,
                        StartDate = new DateTime(2020, 5, 4)


                    }, new Project
                    {
                        Active = true,
                        Description = "Nyt tag",
                        EndDate = new DateTime(2020, 5, 5),
                        IsAccepted = true,
                        IsDone = false,
                        IsFixedPrice = false,
                        Price = 0m,
                        StartDate = new DateTime(2020, 5, 4)


                    }, new Project
                    {

                        Active = true,
                        Description = "Nyt tag",
                        EndDate = new DateTime(2020, 5, 5),
                        IsAccepted = true,
                        IsDone = false,
                        IsFixedPrice = false,
                        Price = 0m,
                        StartDate = new DateTime(2020, 5, 4)


                    }



                ) ;
                context.SaveChanges();
            }
        }
    }
}
