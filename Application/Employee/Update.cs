using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employee
{
    public class Update
    {
        public class EmergencyContact
        {
            public string Name { get; set; }
            public string Relation { get; set; }
            public string PhoneNumber { get; set; }
        }

        public class Command : IRequest
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
            public string PhoneNumber { get; set; }

            //details
            public string PPS { get; set; }

            public DateTime SDate { get; set; }
            public double Salary { get; set; }
            public DateTime BirthdayDate { get; set; }

            //address
            public string AddressLine1 { get; set; }

            public string AddressLine2 { get; set; }
            public string PostCode { get; set; }
            public string County { get; set; }
            public string Country { get; set; }

            //bank details
            public string AccountNumber { get; set; }

            public string SortCode { get; set; }
            public string BIC { get; set; }
            public string IBAN { get; set; }

            //emergency contact
            public string EmergencyName { get; set; }

            public string EmergencyRelation { get; set; }
            public string EmergencyPhoneNumber { get; set; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                //RuleFor(x => x.Role).NotEmpty();
                //RuleFor(x => x.StartingDate).NotEmpty();
                //RuleFor(x => x.Salary).NotEmpty();
            }

            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;
                private readonly UserManager<AppUser> _userManager;

                public Handler(DataContext context, UserManager<AppUser> userManager)
                {
                    _context = context;
                    _userManager = userManager;
                }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)

                {
                    //if (await _context.Users.Where(u => u.Email == request.Email).AnyAsync())
                    //    throw new RestException(HttpStatusCode.BadRequest, new { Email = "This Email Address is Already Registered!" });

                    var user = await _context.EmployeeDetails.Where(u => u.AppUser.Id == request.Id)
                        .Include(u => u.AppUser)
                        .Include(c => c.EmergencyContact)
                        .Include(b => b.BankDetails)
                        .Include(c => c.Address)
                        .FirstOrDefaultAsync();

                    if (user == null)
                        throw new RestException(HttpStatusCode.NotFound, new { User = "Not found" });

                    user.AppUser.FirstName = request.FirstName;
                    user.AppUser.LastName = request.LastName;
                    user.AppUser.PhoneNumber = request.PhoneNumber;
                    user.AppUser.RegisterDate = DateTime.Now;
                    user.AppUser.DisplayName = request.FirstName + " " + request.LastName;

                    ////details
                    user.PPS = request.PPS;
                    user.SDate = DateTime.Now;
                    user.DateOfBirth = request.BirthdayDate;
                    user.Salary = 89000.00;

                    user.Address.AddressLine1 = request.AddressLine1;
                    user.Address.AddressLine2 = request.AddressLine2;
                    user.Address.Country = request.Country;
                    user.Address.County = request.County;
                    user.Address.PostCode = request.PostCode;

                    //bank details
                    user.BankDetails.AccountNumber = request.AccountNumber;
                    user.BankDetails.SortCode = request.SortCode;
                    user.BankDetails.BIC = request.BIC;
                    user.BankDetails.IBAN = request.IBAN;

                    //emergency
                    user.EmergencyContact.Name = request.EmergencyName;
                    user.EmergencyContact.Relation = request.EmergencyRelation;
                    user.EmergencyContact.PhoneNumber = request.EmergencyPhoneNumber;

                    var result = _context.EmployeeDetails.Update(user);

                    var success = await _context.SaveChangesAsync() > 0;
                    if (success) return Unit.Value;

                    throw new RestException(HttpStatusCode.BadRequest, "");
                }
            }
        }
    }
}