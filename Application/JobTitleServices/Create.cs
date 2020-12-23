using Application.Errors;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.JobTitleServices
{
    public class Create
    {
        public class Command : IRequest
        {
            public string title { get; set; }
            public Guid   companyId { get; set; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.title).NotEmpty();
                RuleFor(x => x.companyId).NotEmpty();
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
                    var company = await _context.Company.FirstOrDefaultAsync(c => c.Id.Equals(request.companyId));

                    company.JobTitle.Add( new Domain.JobTitle { Title = request.title });


                    _context.Update(company);

                    if (await _context.SaveChangesAsync() > 0)
                        return Unit.Value;

                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "Could not add a new Job title." });
                }
            }
        }
    }
}