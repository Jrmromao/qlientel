using Application.Errors;
using Domain;
using Domain.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employee
{
    public class Get
    {
        public class Query : IRequest<EmployeeDto>
        {
            public string EmployeeId { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.EmployeeId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, EmployeeDto>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly DataContext _context;

            public Handler(DataContext dataContext, UserManager<AppUser> userManager)
            {
                _context = dataContext;
                _userManager = userManager;
            }

            public async Task<EmployeeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                // var user = await _userManager.FindByEmailAsync(request.Email);
                var user = await _context.Users.Where(u => u.Id == request.EmployeeId)
                    .Include(e => e.EmployeeDetails)
                    .ThenInclude(b => b.BankDetails)
                    .Include(c => c.EmployeeDetails.EmergencyContact)
                    .Include(c => c.EmployeeDetails.Address)
                    .Include(c => c.EmployeeDetails.Department)
                    .Include(c => c.EmployeeDetails.Documents)
                    .FirstOrDefaultAsync();

                if (user == null)
                    throw new RestException(HttpStatusCode.BadRequest);

                if (user != null)
                {
                    var _role = await _userManager.GetRolesAsync(user);
                    // TODO: generate token
                    var userObj = new EmployeeDto
                    {
                        Id = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Role = _role.First(),
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        //details
                        PPS = user.EmployeeDetails.PPS,
                        SDate = user.EmployeeDetails.SDate,
                        Salary = user.EmployeeDetails.Salary,
                        BirthdayDate = user.EmployeeDetails.DateOfBirth,
                        //address
                        AddressLine1 = user.EmployeeDetails.Address.AddressLine1,
                        AddressLine2 = user.EmployeeDetails.Address.AddressLine2,
                        PostCode = user.EmployeeDetails.Address.PostCode,
                        County = user.EmployeeDetails.Address.County,
                        Country = user.EmployeeDetails.Address.Country,
                        //bank details
                        AccountNumber = user.EmployeeDetails.BankDetails.AccountNumber,
                        SortCode = user.EmployeeDetails.BankDetails.SortCode,
                        BIC = user.EmployeeDetails.BankDetails.BIC,
                        IBAN = user.EmployeeDetails.BankDetails.IBAN,
                        //emergency contact
                        EmergencyName = user.EmployeeDetails.EmergencyContact.Name,
                        EmergencyRelation = user.EmployeeDetails.EmergencyContact.Relation,
                        EmergencyPhoneNumber = user.EmployeeDetails.EmergencyContact.PhoneNumber
                    };

                    return userObj;
                }
                throw new RestException(HttpStatusCode.BadRequest, new { Error = "Wrong Username or Password" });
            }
        }
    }
}