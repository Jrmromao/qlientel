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

namespace Application.OfficeServices
{
    public class FindAll
    {
        public class Query : IRequest<List<ItemList>>
        {
            public Guid EmployeeID { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.EmployeeID).NotEmpty();
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

                var companyData = await _context.EmployeeDetails
                  .Include(d => d.Department)
                  .ThenInclude(o => o.Office) 
                  .ThenInclude(c => c.Company)
                  .FirstOrDefaultAsync(e => e.Id == request.EmployeeID);

                var queryData = await _context.Offices.Where(o => o.CompanyId == companyData.Department.Office.CompanyId).ToListAsync();
                var returnList = new List<ItemList>();



                foreach (var item in queryData)
                    returnList.Add(new ItemList { Id = item.Id.ToString(), Text = item.OfficeName, Value = item.Code });
                
                return returnList;

                throw new RestException(HttpStatusCode.BadRequest, new { Error = "Error getting Office Details!" });
            }
        }


    }
}