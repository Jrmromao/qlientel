using Application.CompanyFunc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        [HttpPost("register")]
        public async Task<ActionResult<Unit>> Register(Create.Command command) => await Mediator.Send(command);
    }
}