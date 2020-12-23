using Application.Errors;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchedulePolicyServices
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid CompanyId { get; set; }
            public string Name { get; set; }
            public string DailyHours { get; set; }
            public string WeekHours { get; set; }
            public string AnnualLeaves { get; set; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.CompanyId).NotEmpty();
                RuleFor(x => x.DailyHours).NotEmpty();
                RuleFor(x => x.WeekHours).NotEmpty();
                RuleFor(x => x.AnnualLeaves).NotEmpty();
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
                    var company = await _context.Company.FirstOrDefaultAsync(c => c.Id.Equals(request.CompanyId));

                    company.SchedulePolicy.Add(new Domain.SchedulePolicy
                    {
                        Name = request.Name,
                        WeekHours = request.WeekHours,
                        AnnualLeaves = request.AnnualLeaves,
                        DailyHours = request.DailyHours
                    });
                    _context.Update(company);

                    if (await _context.SaveChangesAsync() > 0)
                        return Unit.Value;

                    throw new RestException(HttpStatusCode.BadRequest, new { Error = "Could not create add Schedule Policy" });
                }
            }
        }
    }
}