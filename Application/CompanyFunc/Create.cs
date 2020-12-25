using Application.Errors;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CompanyFunc
{
    public static class DbContextExtensions
    {
        public static void Reset(this DataContext context)
        {
            var entries = context.ChangeTracker
                                 .Entries()
                                 .Where(e => e.State != EntityState.Unchanged)
                                 .ToArray();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }

    public class Create
    {
        public class Command : IRequest
        {
            public string CompanyName { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string RepeatEmail { get; set; }
            public string Password { get; set; }
            public string RepeatPassword { get; set; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.CompanyName).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.RepeatEmail).EmailAddress().Matches(e => e.Email);
                RuleFor(x => x.Password).Password();
                RuleFor(x => x.RepeatPassword).Password().Matches(p => p.Password); ;
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly UserManager<AppUser> _userManager;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IMailer _mailer;
            private readonly IRazorViewToStringRenderer _renderer;

            public Handler(DataContext context, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IMailer mailer, IRazorViewToStringRenderer renderer)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
                _mailer = mailer;
                _renderer = renderer;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                // make sure email and username are being used
                if (await _context.Company.Where(c => c.Name == request.CompanyName).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "This company is already in our system. Please contact your account manager!" });
                if (await _context.Users.Where(u => u.Email == request.Email).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "This Email Address is Already Registered!" });
                if (await _context.Users.Where(u => u.UserName == request.Username).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "This Username is already registered!" });

                var company = new Company
                {
                    Name = request.CompanyName,
                    Customers = new List<Customer> { new Customer() },
                    Office = new List<Office> {
                        new Office {
                            Address = new Address{ },
                            IsMainHQ = true,
                            Departments = new List<Department>{
                                new Department {
                                Employees = new List<EmployeeDetails>{ new EmployeeDetails
                                {
                                    EmergencyContact = new EmergencyContact{},
                                     BankDetails = new BankDetails{},
                                     AppUser = new AppUser
                                     {
                                         RegisterDate = DateTime.Now,
                                         Email = request.Email,
                                         UserName = request.Username,
                                     },
                                     Address = new Address{ }
                                }
                            }
                        }
                      }
                    }
                  }
                };

                var result = await _userManager.CreateAsync(company.Office.First().Departments.First().Employees.First().AppUser, request.Password);
            //    var companyId = _context.Company.Add(company);
              //  var containerName = request.CompanyName + company.Id.ToString();

             //   var container = Azure.Create.CreateCompanyContainerAsync(containerName.ToLower());

                //if (container.Exception == null)
                //{      }
                    if (result.Succeeded)
                    {
                        var role = await _userManager.AddToRoleAsync(company.Office.First().Departments.First().Employees.First().AppUser, "Admin");
                        await _context.SaveChangesAsync();
                        return Unit.Value;
                    }
          
                else
                {
                    DbContextExtensions.Reset(_context);
                    throw new RestException(HttpStatusCode.BadRequest, "Error adding a new company!");
                }

                throw new RestException(HttpStatusCode.BadRequest, "Error adding a new company!");
            }
        }
    }
}