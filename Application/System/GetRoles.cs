using Application.Errors;
using MediatR;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.System
{
    public class GetRoles
    {
        public class Query : IRequest<List<ItemList>>
        {
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
                var roles = _context.Roles.ToList();
                var rolesDto = new List<ItemList>();

                foreach (var item in roles)
                    rolesDto.Add(new ItemList { Value = item.Name, Text = item.Name, Id = item.Id });

                return rolesDto;

                throw new RestException(HttpStatusCode.BadRequest, new { Error = "Error getting roles" });
            }
        }
    }
}