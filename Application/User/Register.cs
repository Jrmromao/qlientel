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
using Templates.ViewModels;

namespace Application.User
{
    public class Register
    {
        public class Command : IRequest<User>
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

        public class Handler : IRequestHandler<Command, User>
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

            public async Task<User> Handle(Command request, CancellationToken cancellationToken)

            {
                // make sure email and username are being used

                if (await _context.Company.Where(c => c.Name == request.CompanyName).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "This company is already in our system. Please contact your account manager!" });
                if (await _context.Users.Where(u => u.Email == request.Email).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "This Email Address is Already Registered!" });
                if (await _context.Users.Where(u => u.UserName == request.Username).AnyAsync())
                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "This Username is Already Registered!" });

                var company = new Company
                {
                    Customers = new List<Customer>() { },
                    Name = request.CompanyName,
                    Office = new List<Office> {
                        new Office {
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
                                     }
                                }
                            }
                        }
                            }
                        }
                    }
                };

                _context.Company.Add(company);

                //var result = await _context.SaveChangesAsync();
             var result = await _userManager.CreateAsync(company.Office.First().Departments.First().Employees.First().AppUser, request.Password);
                if (result.Succeeded)
                {
                    var role = await _userManager.AddToRoleAsync(company.Office.First().Departments.First().Employees.First().AppUser, "Manager");
                    if (role.Succeeded)

                        //   await sendEmailAsync(_renderer, user, _mailer);

                        return new User
                        {
                        };
                }

                throw new RestException(HttpStatusCode.BadRequest, new { error = "Problem Registering!" });
            }

            private async Task SendEmailAsync(IRazorViewToStringRenderer renderer, AppUser user, IMailer mailer)
            {
                var model = new HelloWorldViewModel("https://www.google.com");

                const string view = "/Views/Emails/HelloWorld/HelloWorld";
                var htmlBody = await renderer.RenderViewToStringAsync($"{view}Html.cshtml", model);
                var subject = "no reply - Email Comfirmation";
                await mailer.SendEmailAsync(user.Email, subject, htmlBody);
            }
        }
    }
}