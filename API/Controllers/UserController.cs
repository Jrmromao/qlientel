using Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    public class UserController : BaseController
    {
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(Login.Query query) => await Mediator.Send(query);

        [HttpGet("current-user")]
        public async Task<ActionResult<User>> CurentUser() => await Mediator.Send(new CurrentUser.Query());
    }
}