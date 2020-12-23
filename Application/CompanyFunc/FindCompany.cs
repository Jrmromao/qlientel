using Application.Errors;
using AutoMapper;
using Domain;
using Domain.DTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CompanyFunc
{
    public class CompanyTotals
    {
        public string CompanyName { get; set; }
        public int TotalOffices { get; set; }
        public int TotalDepartments { get; set; }
        public int TotalEmployee { get; set; }
    }

    public class FindCompany
    {
        public class Query : IRequest<CompanyDto>
        {
            public Guid EmployeeId { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.EmployeeId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, CompanyDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext dataContext, IMapper mapper)
            {
                _context = dataContext;
                _mapper = mapper;
            }

            public async Task<CompanyDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryData = await _context.EmployeeDetails
                    .Include(d => d.Department)
                    .ThenInclude(o => o.Office)
                    .ThenInclude(c => c.Company)
                    .FirstOrDefaultAsync(e => e.Id == request.EmployeeId);

                var companyQuery = await _context.Company.Include(o => o.Office).ThenInclude(d => d.Departments).FirstOrDefaultAsync(c => c.Id == queryData.Department.Office.Company.Id);

                return _mapper.Map<Company, CompanyDto>(companyQuery);

                throw new RestException(HttpStatusCode.BadRequest, new { Error = "Sorry, we couldn't return the requested company details!" });
            }
        }
    }
}