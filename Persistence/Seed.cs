using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var CompanyAddress = new Address
                {
                    AddressLine1 = "Line 1",
                    AddressLine2 = "Line 2",
                    County = "Portalegre",
                    PostCode = "7400 - 166",
                    Country = "Portugal",
                };
                var address = new Address
                {
                    AddressLine1 = "Line 1",
                    AddressLine2 = "Line 2",
                    County = "Portalegre",
                    PostCode = "7400 - 166",
                    Country = "Portugal",
                };

                var company = new Company
                {
                    Name = "Martilux",

                    Office = new List<Office> {
                        new Office {
                            Address = CompanyAddress,
                            Code = "ML01",
                            IsMainHQ = true,
                            Departments = new List<Department>{
                                new Department { Name = "IT",
                                Employees = new List<EmployeeDetails>{ new EmployeeDetails
                                {
                                    Address =address,
                                    EmergencyContact = new EmergencyContact{ Name = "Joao Romao",Relation = "Brother",PhoneNumber = "09709876543"},
                                     BankDetails = new BankDetails{},
                                     AppUser = new AppUser
                                     {
                                         DisplayName = "Joao Romao",
                                         UserName = "jrmromao",
                                         Email = "jrmromao@gmail.com",
                                         RegisterDate = DateTime.Now,
                                     }
                                }
                            }
                        } }
                        }
                    }
                };

                var user = company.Office.First().Departments.First().Employees.First().AppUser;

                await userManager.CreateAsync(user, "Opel2010..");

                var role2 = await userManager.AddToRoleAsync(user, "Admin");

                //  var role1 = await userManager.AddToRoleAsync(userList[0], "User");
            }
        }
    }
}