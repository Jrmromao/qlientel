using Application.Errors;
using AutoMapper;
using Domain;
using Domain.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
  public  class GetLeaves
    {

        public class Query : IRequest<LeavesDto>
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

        public class Handler : IRequestHandler<Query, LeavesDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext dataContext, IMapper mapper)
            {
                _context = dataContext;
                _mapper = mapper;
            }

            public async Task<LeavesDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var leaves =   await _context.Leave.FirstOrDefaultAsync(l => l.EmployeeId == request.EmployeeID);

                var leavesToReturn = _mapper.Map<Leaves, LeavesDto>(leaves);

                return leavesToReturn;

                throw new RestException(HttpStatusCode.BadRequest, new { Error = "Sorry, we couldn't return the requested department details!" });
            }
        }
    }
}
