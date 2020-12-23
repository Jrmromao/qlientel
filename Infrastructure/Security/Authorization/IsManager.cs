using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Persistence;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Infrastructure.Security.Authorization
{
    public class IsManager : IAuthorizationRequirement
    {
    }

    public class IsManagerHandler : AuthorizationHandler<IsAdmin>
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public IsManagerHandler(IHttpContextAccessor accessor, DataContext context, UserManager<AppUser> userManager)
        {
            _accessor = accessor;
            _context = context;
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IsAdmin requirement)
        {
            var currrentUserName =
                _accessor.HttpContext.User?.Claims?.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = _context.Users.FirstOrDefault(u => u.UserName.Equals(currrentUserName));
            var _role = _userManager.GetRolesAsync(user);
            var usersInRole = _context.UserRoles.FirstOrDefault(r => r.UserId.Equals(user.Id));
            var role = _context.Roles.FirstOrDefault(r => r.Id == usersInRole.RoleId);

            if (string.IsNullOrEmpty(role.Name) || role.Name != "Admin")
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
