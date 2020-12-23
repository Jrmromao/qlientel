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

namespace Application
{
    public class RequestLeaves
    {
             public class Command : IRequest
        {
            public Guid EmployeeId { get; set; }
            public string FromDate { get; set; }
            public string ToDate { get; set; }
            public string Note { get; set; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.EmployeeId).NotEmpty();
                RuleFor(x => x.FromDate).NotEmpty();
                RuleFor(x => x.ToDate).NotEmpty().EmailAddress();
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

                    var leaves = await _context.Leave.FirstOrDefaultAsync(e => e.EmployeeId == request.EmployeeId);

                    if (leaves == null)
                        throw new RestException(HttpStatusCode.NotFound, new { Error = "Not found" });

                    else
                    {
                        // get the department where the user is working and the manager for that department
                        // need to add a record to the leave request. but i'll do it tomorrow because i'm going to get a shower now.
                        var department = _context.Departments.Include(u => u.Employees).ThenInclude(a => a.AppUser).Where(e =>
                        e.Id == e.Employees.FirstOrDefault(o => o.Id == request.EmployeeId).Id);
                    }


                    var success = await _context.SaveChangesAsync() > 0;
                    if (success) return Unit.Value;

                    throw new RestException(HttpStatusCode.BadRequest, "");
                }
            }
        }
    }
}