using Application.Errors;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Templates.ViewModels;

namespace Application.User
{

    /// <summary>
    /// when a user logs in the system should return the latest events
    ///  the user functionality will then be manage in the frontend (also in the banckend controllers)
    /// </summary>
    public class Login
    {
        public class Query : IRequest<User>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;
            private readonly IMailer _mailer;
            private readonly DataContext _context;
            private readonly IRazorViewToStringRenderer _renderer;

            public Handler(DataContext dataContext, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
                IJwtGenerator jwtGenerator, IMailer mailer, IRazorViewToStringRenderer renderer)
            {
                _context = dataContext;
                _signInManager = signInManager;
                _jwtGenerator = jwtGenerator;
                _mailer = mailer;
                _renderer = renderer;
                _userManager = userManager;
            }

            public async Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Where(u => u.Email.Equals(request.Email))
                    .Include(d => d.EmployeeDetails).ThenInclude(d => d.Department).ThenInclude(o => o.Office).ThenInclude(c=>c.Company).FirstOrDefaultAsync();

                if (user == null)
                    throw new RestException(HttpStatusCode.Unauthorized);

                var result = await _signInManager
                    .CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    await _userManager.UpdateAsync(user);
                    
                    
                    var _role = await _userManager.GetRolesAsync(user);
                  
                    
                    if (_role != null)
                    return new User()
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
                user.AccessFailedCount += 1;
                await _userManager.UpdateAsync(user);

                throw new RestException(HttpStatusCode.BadRequest, new { Error = "Wrong Username or Password" });
            }
        
        }
    }
}