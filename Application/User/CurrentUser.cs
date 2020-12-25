using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class CurrentUser
    {
        public class Query : IRequest<User> { }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly DataContext _context;
            private readonly UserManager<AppUser> _userManager;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, UserManager<AppUser> userManager, IJwtGenerator jwtGenerator, IUserAccessor userAccessor)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerator = jwtGenerator;
                _userAccessor = userAccessor;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Where(u => u.UserName == _userAccessor.GetCurrentUsername())
                    .Include(d => d.EmployeeDetails)
                    .ThenInclude(dep => dep.Department)
                    .ThenInclude(o=> o.Office)
                    .ThenInclude(c => c.Company)
                    .FirstOrDefaultAsync();

                var _role = await _userManager.GetRolesAsync(user);

                return new User
                {
                    Username = user.UserName,
                    Token = _jwtGenerator.CreateToken(user),
                    DisplayName = user.DisplayName != null ? user.DisplayName : "",
                    Email = user.Email,
                    Role = _role,
                    Id = user.Id.ToString(),
                    //DepartmentId = user.EmployeeDetails.DepartmentId.ToString(),
                    //EmployeeId = user.EmployeeDetailsId.ToString(),
                    //CompanyId = user.EmployeeDetails.Department.Office.CompanyId,
                    //company = user.EmployeeDetails.Department.Office.Company.Name,
                    //Department = user.EmployeeDetails.Department.Name


                };
            }
        }
    }
}