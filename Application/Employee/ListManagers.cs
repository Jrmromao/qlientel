using Application.Errors;
using Application.System;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Employee
{
    public class ListManagers
    {
        public class Query : IRequest<List<ItemList>>
        {
            public Guid CompantId { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.CompantId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, List<ItemList>>
        {
            private readonly DataContext _context;
            private readonly UserManager<AppUser> _userManager;

            public Handler(DataContext dataContext, UserManager<AppUser> userManager)
            {
                _context = dataContext;
                _userManager = userManager;
            }

            public async Task<List<ItemList>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryData = await _context.Company.Include(o => o.Office)
                    .ThenInclude(d => d.Departments)
                    .ThenInclude(e => e.Employees)
                    .ThenInclude(u => u.AppUser)
                    .FirstOrDefaultAsync(c => c.Id.Equals(request.CompantId));

                var returnList = new List<ItemList>();

                foreach (var i in queryData.Office)
                {
                    foreach (var j in i.Departments)
                    {
                        foreach (var x in j.Employees)
                        {
                            var _role = await _userManager.GetRolesAsync(x.AppUser);
                            if (!_role[0].Equals("User"))
                                returnList.Add(new ItemList { Id = x.AppUser.Id, Text = x.AppUser.DisplayName + " - "+_role[0], Value = x.AppUser.Id });
                        }
                    }
                }

                return returnList;

                throw new RestException(HttpStatusCode.BadRequest, new { Error = "Error getting Office Details!" });
            }
        }
    }
}