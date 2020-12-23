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
    public class Update
    {
        public class Command : IRequest
        {
            public Guid SchedulePolicyId { get; set; }
            public string Name { get; set; }
            public string DailyHours { get; set; }
            public string WeekHours { get; set; }
            public string AnnualLeaves { get; set; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.SchedulePolicyId).NotEmpty();
                RuleFor(x => x.Name).NotEmpty();
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
                    var policy = await _context.SchedulePolicie.FirstOrDefaultAsync(s => s.Id.Equals(request.SchedulePolicyId));

                    policy.DailyHours = request.AnnualLeaves;
                    policy.WeekHours = request.WeekHours;
                    policy.Name = request.Name;
                    policy.AnnualLeaves = request.AnnualLeaves;

                    _context.Update(policy);

                    if (await _context.SaveChangesAsync() > 0)
                        return Unit.Value;

                    throw new RestException(HttpStatusCode.BadRequest,
                        new { Error = "Could not update this Job Title." });
                }
            }
        }
    }
}