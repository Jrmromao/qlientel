using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Persistence;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OfficeServices
{
    public class CreateOffice
    {
        public class Command : IRequest
        {
            public Guid CompanyId { get; set; }
            public bool IsMainHQ { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string PostCode { get; set; }
            public string County { get; set; }
            public string Country { get; set; }
            public string Name { get; set; }
            public string Code { get; set; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.CompanyId).NotEmpty();
            }

            public class Handler : IRequestHandler<Command>
            {
                private readonly DataContext _context;
                private readonly IHttpContextAccessor _accessor;

                public Handler(DataContext context, IHttpContextAccessor accessor)
                {
                    _context = context;
                    _accessor = accessor;
                }

                public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
                {
                    var company = await _context.Company.FindAsync(request.CompanyId);

                    company.Office.Add(new Office
                    {
                        IsMainHQ = request.IsMainHQ,
                        Address = new Address
                        {
                            AddressLine1 = request.AddressLine1,
                            AddressLine2= request.AddressLine2,
                            Country = request.Country,
                            County =  request.County,
                            PostCode = request.PostCode

                        },
                        OfficeName = request.Name,
                        Code = request.Code,
                        Departments = new List<Department> { }
                    });

                    _context.Update(company);

                    if (await _context.SaveChangesAsync() > 0)
                        return Unit.Value;

                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "Couldn't add new Company! " });
                }
            }
        }
    }
}