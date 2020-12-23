using Application.Errors;
using AutoMapper;
using Domain;
using Domain.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OfficeServices
{
    public class FindOffice
    {
        public class Query : IRequest<OfficeDto>
        {
            public  string OfficeId { get; set; }
        }

        public class Handler : IRequestHandler<Query, OfficeDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext dataContext, IMapper mapper)
            {
                _context = dataContext;
                _mapper = mapper;
            }

            public async Task<OfficeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var officeData = await _context.Offices.Include(d => d.Departments).ThenInclude(e => e.Employees).FirstOrDefaultAsync(o => o.Id == Guid.Parse(request.OfficeId));
                var officeToReturn = _mapper.Map<Office, OfficeDto>(officeData);
                return officeToReturn;

                throw new RestException(HttpStatusCode.BadRequest, new { Error = "Error getting Office Details!" });
            }
        }
    }
}