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
                if (context.Customers.Any())
                {
                    return;   // DB has been seeded
                }
                var NormalCustomer = new CustomerDiscountType
                {
                    Name = "Normal",
                    DiscountPercent = 0,
                    Active = true
                };
                var BonusCustomer = new CustomerDiscountType
                {
                    Name = "Bonus",
                    DiscountPercent = 10,
                    Active = true
                };
                var SuperCustomer = new CustomerDiscountType
                {
                    Name = "Super",
                    DiscountPercent = 15,
                    Active = true
                };

                context.Customers.AddRange(
                    new Customer
                    {
                        Name = "Hans Hansen",
                        Phone = "12345678",
                        Address = "Hansvej 1, 1111 Hansby",
                        Email = "Hans@gmail.com",
                        Active = true,
                        CustomerDiscountType = NormalCustomer
                         
                    },


                    new Customer
                    {
                        Name = "Ole Olsen",
                        Phone = "87654321",
                        Address = "Olevej 2, 2222 Oleby",
                        Email = "Ole@gmail.com",
                        Active = true,
                        CustomerDiscountType = SuperCustomer
                        

                       

                    },
                     new Customer
                     {
                         Name = "Bent Bentsen",
                         Phone = "12121212",
                         Address = "Bentvej 3, 3333 Bentby",
                         Email = "Bent@gmail.com",
                         Active = true,
                         CustomerDiscountType = NormalCustomer
                     },
                      new Customer
                      {
                          Name = "Erik Eriksen",
                          Phone = "141414141",
                          Address = "Erikvej 4, 4444 Erikeby",
                          Email = "Erik@gmail.com",
                          Active = true,
                          CustomerDiscountType = BonusCustomer

                      },
                       new Customer
                       {
                           Name = "Knud Knudsen",
                           Phone = "565656565",
                           Address = "Knudvej 5, 5555 Knudby",
                           Email = "Knud@gmail.com",
                           Active = true,
                           CustomerDiscountType = SuperCustomer
                       }


                );
                var Discount1 = new ItemDiscountType
                {
                    DiscountPercentage = 5,
                    StartDate = new DateTime(2020,2,20),
                    EndDate = new DateTime(2020, 3, 20)
                    
                    
                };
                var Discount2 = new ItemDiscountType
                {
                    DiscountPercentage = 15,
                    StartDate = new DateTime(2020, 4, 20),
                    EndDate = new DateTime(2020, 5, 20),
                    Amount = 10
                    
                };
                var Discount3 = new ItemDiscountType
                {
                    DiscountPercentage = 30,
                    StartDate = new DateTime(2020, 6, 20),
                    EndDate = new DateTime(2020, 7, 20),
                    Amount = 20
                    
                };

                context.Items.AddRange(
                    new Item
                    {
                        Name = "Træ",
                        Price = 7.99M,
                        Active = true,
                        Discount = Discount1,
                        
                    },
                    new Item
                    {
                        Name = "Vindu",
                        Price = 7.99M,
                        Active = true,
                        Discount = Discount2,
                    },
                    new Item
                    {
                        Name = "Søm",
                        Price = 7.99M,
                        Active = true,
                        Discount = Discount3,
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

                
                var department = new Department { Name = "Vejle" };
                var type = new EmployeeType { HourlyPrice = 200, Title = "Tømrer" };
                var type1 = new EmployeeType { HourlyPrice = 0, Title = "musse" };
                var specialty = new Specialty { Bonus = 100, Title = "Velux" };
                
                Employee emp1 = new Employee { Name = "Jørgen Clevin", Active = true, Phone = "1241234",Department = department, Type = type };
                Employee emp2 = new Employee { Name = "Brian Jørgensen", Active = true, Phone = "1241234",Department = department, Type = type };
                context.Employees.AddRange(
                    new Employee
                    {
                        Name = "Brian Nielsen",
                        Phone = "67589342",
                        Active = true,
                        Type = type,
                        
                        Manager = emp1,
                        Department = department
                    },
                    new Employee
                    {
                        Name = "Henrik Kofoed",
                        Phone = "78652341",
                        Active = true,
                        Manager = emp1,
                        Department = department,
                        Type = type
                    },
                    new Employee
                    {
                        Name = "Thomas Troelsen",
                        Phone = "+4534782311",
                        Active = true,
                        Manager = emp2,
                        Department = department,
                        Type = type
                    },
                    new Employee
                    {
                        Name = "Rasmus Paludan",
                        Phone = "54672291",
                        Active = true,
                        Manager = emp2,
                        Department = department,
                        Type = type
                    },
                    new Employee
                    {
                        Name = "Flemming Leth",
                        Phone = "23456789",
                        Active = true,
                        Department = department,
                        Type = type
                    },
                    new Employee
                    {
                        Name = "Susanne",
                        Phone = "67589372",
                        Active = true,
                        Type = type1,
                        
                        Department = department
                    }
                );
                Customer cus1 = new Customer { Name = "Hans Hushaj", Phone = "32345676", Address = "Hammerhajvej 34", Email = "Hammer@haj.dk", Active = true,CustomerDiscountType=NormalCustomer };

                //WorkingHours workingHours1 = new WorkingHours { Amount = 3, HourlyPrice = 400, Employee = emp1 };
                //WorkingHours workingHours2 = new WorkingHours { Amount = 6, HourlyPrice = 600, Employee = emp1 };
                //var Workingóurlist = new List<WorkingHours>();
                ProjectDriving projectDriving1 = new ProjectDriving { Amount = 25, Employee = emp1, UnitPrice = 2 };
                ProjectDriving projectDriving2 = new ProjectDriving { Amount = 25, Employee = emp1, UnitPrice = 2 };
                ProjectDriving projectDriving3 = new ProjectDriving { Amount = 2, Employee = emp1, UnitPrice = 795 };
                ProjectEmployee projectEmployee = new ProjectEmployee { Employee = emp1, EstWorkingHours = 50};
                var usedItem1 = new ProjectUsedItem { Amount = 10, ItemID = 1, Price = 7.99m };
                var usedItem2 = new ProjectUsedItem { Amount = 10, ItemID = 1, Price = 7.99m };
                var usedItem3 = new ProjectUsedItem { Amount = 10, ItemID = 1, Price = 7.99m };
                var usedItem4 = new ProjectUsedItem { Amount = 10, ItemID = 2, Price = 7.99m };
                var usedItem5 = new ProjectUsedItem { Amount = 10, ItemID = 2, Price = 7.99m };
                var usedItem6 = new ProjectUsedItem { Amount = 10, ItemID = 2, Price = 7.99m };

                var assignedItem1 = new ProjectAssignedItem { Amount = 20, ItemID = 1, Price = 7.99m };
                var assignedItem2 = new ProjectAssignedItem { Amount = 20, ItemID = 1, Price = 7.99m };
                var assignedItem3 = new ProjectAssignedItem { Amount = 20, ItemID = 1, Price = 7.99m };
                var assignedItem4 = new ProjectAssignedItem { Amount = 20, ItemID = 2, Price = 7.99m };
                var assignedItem5 = new ProjectAssignedItem { Amount = 20, ItemID = 2, Price = 7.99m };
                var assignedItem6 = new ProjectAssignedItem { Amount = 20, ItemID = 2, Price = 7.99m };

                var workingHours1 = new WorkingHours { Employee = emp1, Amount = 10 };
                var workingHours2 = new WorkingHours { Employee = emp1, Amount = 10 };
                var workingHours3 = new WorkingHours { Employee = emp2, Amount = 10 };
                var workingHours4 = new WorkingHours { Employee = emp2, Amount = 10 };

                ProjectEmployee projectEmployee2 = new ProjectEmployee { Employee = emp2, EstWorkingHours = 20 };



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
                        ESTdriving = 20.5,
                        //  WorkingHours = Workingóurlist,
                        ProjectDrivings = new List<ProjectDriving> { projectDriving1, projectDriving2, projectDriving3 },
                        ProjectEmployees = new List<ProjectEmployee> { projectEmployee, projectEmployee2 },
                        UsedItems = new List<ProjectUsedItem> { usedItem1, usedItem2, usedItem3, usedItem4, usedItem5, usedItem6 },
                        AssignedItems = new List<ProjectAssignedItem> { assignedItem1, assignedItem2, assignedItem3, assignedItem4, assignedItem5, assignedItem6 },
                        WorkingHours = new List<WorkingHours> { workingHours1, workingHours2, workingHours3, workingHours4 },
                        Customer = cus1



                    },
                    new Project
                    {
                        Active = true,
                        Description = "Ny Carport",
                        EndDate = new DateTime(2020, 5, 5),
                        IsAccepted = true,
                        IsDone = false,
                        IsFixedPrice = false,
                        Price = 0m,
                        StartDate = new DateTime(2020, 5, 4),
                        ESTdriving = 30.5,
                        Customer = cus1



                    }, new Project
                    {
                        Active = true,
                        Description = "Ny terrese",
                        EndDate = new DateTime(2020, 5, 5),
                        IsAccepted = true,
                        IsDone = false,
                        IsFixedPrice = false,
                        Price = 0m,
                        StartDate = new DateTime(2020, 5, 4),
                        ESTdriving = 45.8,
                        Customer = cus1

                    }, new Project
                    {
                        Active = true,
                        Description = "Ny dør",
                        EndDate = new DateTime(2020, 5, 5),
                        IsAccepted = true,
                        IsDone = false,
                        IsFixedPrice = false,
                        Price = 0m,
                        StartDate = new DateTime(2020, 5, 4),
                        ESTdriving = 78.9


                    }, new Project
                    {

                        Active = true,
                        Description = "Nyt gulv",
                        EndDate = new DateTime(2020, 5, 5),
                        IsAccepted = true,
                        IsDone = false,
                        IsFixedPrice = false,
                        Price = 0m,
                        StartDate = new DateTime(2020, 5, 4),
                        ESTdriving = 1547.8


                    }  
                    
                );
                context.SaveChanges();
            }
        }
    }
}
