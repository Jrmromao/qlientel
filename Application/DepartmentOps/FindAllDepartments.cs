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

namespace Application.DepartmentOps
{
    public class FindAllDepartments
    {
        public class Query : IRequest<List<ItemList>>
        {
            public Guid OfficeId { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.OfficeId).NotEmpty();
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
                var departments = _context.Departments.Include(o => o.Office).Where(o => o.Office.Id.Equals(request.OfficeId)).ToList();

                var returnList = new List<ItemList>();

                foreach (var item in departments)
                    returnList.Add(new ItemList { Id = item.Id.ToString(), Text = item.Name, Value = item.Id.ToString() });

                return returnList;

                throw new RestException(HttpStatusCode.BadRequest, new { Error = "Error getting Office Details!" });
            }
        }
    }
}