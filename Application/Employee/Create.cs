using Application.Errors;
using Application.Interfaces;
using Azure.BlobOps;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
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

namespace Application.Employee
{
    public class Create
    {
        public class Command : IRequest
        {
            // manager department ID
            public Guid DepartmentID { get; set; }

            public string ReportsTo { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
            public string StartingDate { get; set; }
            public string Salary { get; set; }
            public string SchedulePolicy { get; set; }
            public string Title { get; set; }
            public IFormFile ContractDoc { get; set; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DepartmentID).NotEmpty();
                RuleFor(x => x.ReportsTo).NotEmpty();
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Role).NotEmpty();
                RuleFor(x => x.StartingDate).NotEmpty();
                RuleFor(x => x.Salary).NotEmpty();
                RuleFor(x => x.SchedulePolicy).NotEmpty();
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.ContractDoc).NotEmpty();
            }

            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;
                private readonly UserManager<AppUser> _userManager;
                private readonly IMailer _mailer;
                private readonly IRazorViewToStringRenderer _renderer;

                public Handler(DataContext context, UserManager<AppUser> userManager, IMailer mailer, IRazorViewToStringRenderer renderer)
                {
                    _context = context;
                    _userManager = userManager;
                    _mailer = mailer;
                    _renderer = renderer;
                }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                    var tempPass = "Opel2010..";
                    if (await _context.Users.Where(u => u.Email == request.Email).AnyAsync())
                        throw new RestException(HttpStatusCode.BadRequest, new { Email = "This Email Address is Already Registered!" });

                    var department = await _context.Departments
                        .Include(e => e.Employees).Include(o => o.Office).ThenInclude(c => c.Company)
                        .FirstOrDefaultAsync(d => d.Id.Equals(request.DepartmentID));

                    var leaves = await _context.SchedulePolicie.Where(c => c.CompanyId.Equals(department.Office.CompanyId)).FirstOrDefaultAsync();

                    var reportTo = await _context.Users.FindAsync(request.ReportsTo);

                    var employeeDetails = new EmployeeDetails
                    {
                        Salary = Convert.ToDouble(request.Salary),
                        BankDetails = new BankDetails { },
                        Address = new Address { },
                        Department = department,
                        EmergencyContact = new EmergencyContact { },
                        Documents = new List<Documents>(),
                        SchedulePolicy = request.SchedulePolicy,
                        Title = request.Title,
                        SDate = Convert.ToDateTime(request.StartingDate),
                        ReportsTo = reportTo,
                        ReportsId = Guid.Parse(request.ReportsTo),
                        Leaves = new Leaves
                        {
                            Balance = leaves.AnnualLeaves,
                            TakenToDate = "0"
                        }
                    };

                    var user = new AppUser
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        UserName = request.Email,
                        RegisterDate = DateTime.Now,
                        DisplayName = request.FirstName + " " + request.LastName,

                        EmployeeDetails = employeeDetails
                    };

                    // update the department manager
                    if (request.Role == "Manager")
                        department.ManagerId = Guid.Parse(user.Id);

                    _context.Update(department);

                    var cotainerName = department.Office.Company.Name + department.Office.CompanyId;
                    var employeeDir = user.Id;
                    var docUri = await UploadBlob.UploadBlopToContainner(cotainerName, "employee", employeeDir, request.ContractDoc);
                    if (docUri != null)
                        employeeDetails.Documents.Add(new Documents { Uri = docUri.ToString() });

                    var result = await _userManager.CreateAsync(user, tempPass);
                    if (result.Succeeded)
                    {
                        var role = await _userManager.AddToRoleAsync(user, request.Role);

                        if (role.Succeeded)
                        {
                            _context.Events.Add(new Events
                            {
                                CompanyId = leaves.CompanyId,
                                Description = $"{user.DisplayName} was added to the System",
                                Employee = new List<EmployeeDetails>
                                {
                                    employeeDetails
                                }
                            });

                            await _context.SaveChangesAsync();
                            // should also intern an event to the event table
                            // await sendEmailAsync(_renderer, user, _mailer);
                            // send an email to the user you just created  and return Unit.Value
                            return Unit.Value;
                        }
                    }
                    throw new RestException(HttpStatusCode.BadRequest, result.Errors);
                }

                private async Task sendEmailAsync(IRazorViewToStringRenderer renderer, AppUser user, IMailer mailer)
                {
                    var model = new HelloWorldViewModel("https://www.google.com");

                    const string view = "/Views/Emails/AccountConfirmation/EmailConfirmation";
                    var htmlBody = await renderer.RenderViewToStringAsync($"{view}Html.cshtml", model);
                    var subject = "no reply - Email Confirmation";
                    await mailer.SendEmailAsync(user.Email, subject, htmlBody);
                }
            }
        }
    }
}