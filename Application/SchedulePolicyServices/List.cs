using Application.Errors;
using Application.System;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SchedulePolicyServices
{
    public class List
    {
        public class Query : IRequest<List<ItemList>>
        {
            public Guid CompanyId { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.CompanyId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, List<ItemList>>
        {
            private readonly DataContext _context;

            public Handler(DataContext dataContext)
            {
                _context = dataContext;
            }

            public async Task<List<ItemList>> Handle(Query request, CancellationToken cancellationToken)
            {
                var resturnData = await _context.SchedulePolicie
                    .Where(c => c.CompanyId.Equals(request.CompanyId)).ToListAsync();

                var returnList = new List<ItemList>();

                foreach (var i in resturnData)
                {
                    returnList.Add(new ItemList
                    {
                        Id = i.Id.ToString(),
                        Text = i.Name,
                        Value = i.Name,
                    });
                }

                return returnList;
                throw new RestException(HttpStatusCode.BadRequest,
                    new { Error = "Could not return Schedule policies for the given company!" });
            }
        }
    }
}
