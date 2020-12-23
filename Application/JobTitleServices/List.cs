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

namespace Application.JobTitleServices
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
                var jobTitles = await _context.JobTitles
                    .Where(c => c.CompanyId.Equals(request.CompanyId)).ToListAsync();

                var returnList = new List<ItemList>();

                foreach (var i in jobTitles)
                {
                    returnList.Add(new ItemList
                    {
                        Id = i.Id.ToString(),
                        Text = i.Title,
                        Value = i.Title
                    });
                }

                return returnList;
                throw new RestException(HttpStatusCode.BadRequest,
                    new { Error = "Wrong Username or Password" });
            }
        }
    }
}