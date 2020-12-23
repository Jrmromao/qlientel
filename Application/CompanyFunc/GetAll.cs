using Application.Errors;
using AutoMapper;
using Domain;
using Domain.DTOs;
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

namespace Application.CompanyFunc
{
    public class GetAll
    {
        public class Query : IRequest<List<EmployeeDetailsDto>>
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

        public class Handler : IRequestHandler<Query, List<EmployeeDetailsDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly UserManager<AppUser> _userManager;

            public Handler(DataContext dataContext, UserManager<AppUser> userManager, IMapper mapper)
            {
                _userManager = userManager;
                _context = dataContext;
                _mapper = mapper;
            }

            public async Task<List<EmployeeDetailsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var companyQuery = await _context.Company.Include(o => o.Office)
                    .ThenInclude(d => d.Departments)
                    .ThenInclude(e => e.Employees)
                    .ThenInclude(u => u.AppUser).FirstOrDefaultAsync(c => c.Id == request.CompanyId);

                var returnlist = new List<EmployeeDetailsDto>();

                foreach (var c in companyQuery.Office)
                {
                    foreach (var d in c.Departments)
                    {
                        foreach (var e in d.Employees)
                        {
                            var role = await _userManager.GetRolesAsync(e.AppUser);
                            var employeeDto = _mapper.Map<EmployeeDetails, EmployeeDetailsDto>(e);
                            employeeDto.Role = role[0];
                            returnlist.Add(employeeDto);
                        }
                    }
                }

                return returnlist;
                throw new RestException(HttpStatusCode.BadRequest,
                    new { Error = "Sorry, we couldn't return the Employees details!" });
            }
        }
    }
}