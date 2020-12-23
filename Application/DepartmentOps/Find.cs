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

namespace Application.DepartmentOps
{
    public class Find
    {
        public class Query : IRequest<DepartmentDto>
        {
            public Guid Id { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, DepartmentDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext dataContext, IMapper mapper)
            {
                _context = dataContext;
                _mapper = mapper;
            }

            public async Task<DepartmentDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var departmentData =
                    await _context.Departments.Include(e => e.Employees).ThenInclude(d => d.AppUser).FirstOrDefaultAsync(d => d.Id == request.Id);
                var departmentToReturn = _mapper.Map<Department, DepartmentDto>(departmentData);
                return departmentToReturn;

                throw new RestException(HttpStatusCode.BadRequest, new { Error = "Sorry, we couldn't return the requested department details!" });
            }
        }
    }
}