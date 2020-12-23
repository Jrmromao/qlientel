using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.DepartmentOps
{
    public class CreateDepartment
    {
        public class Command : IRequest
        {
            public string OfficeCode { get; set; }
            public string Name { get; set; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.OfficeCode).NotEmpty();
            }

            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;

                public Handler(DataContext context)
                {
                    _context = context;
                }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                    try
                    {
                        var office = await _context.Offices.FirstOrDefaultAsync(n => n.Code.Equals(request.OfficeCode));

                        if (office != null)
                        {
                            office.Departments.Add(new Department
                            {
                                Name = request.Name,
                                Employees = new List<EmployeeDetails> { }
                            });
                        }

                        _context.Update(office);

                        if (await _context.SaveChangesAsync() > 0)
                            return Unit.Value;
                    }
                    catch (RestException ex)
                    {
                        throw new RestException(HttpStatusCode.BadRequest, new { Error = ex.Message });
                    }
                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "Couldn't add new Department! " });
                }
            }
        }
    }
}