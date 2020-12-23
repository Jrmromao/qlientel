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
    public class Update
    {
        public class Command : IRequest
        {
            public Guid JobTitileId { get; set; }
            public string Title { get; set; }
        }

        private class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.JobTitileId).NotEmpty();
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
                    var fobTitle = await _context.JobTitles.FirstOrDefaultAsync(c => c.Id.Equals(request.JobTitileId));

                    fobTitle.Title = request.Title;

                    _context.Update(fobTitle);

                    if (await _context.SaveChangesAsync() > 0)
                        return Unit.Value;

                    throw new RestException(HttpStatusCode.BadRequest,
                        new { Error = "Could not update this Job Title." });
                }
            }
        }
    }
}