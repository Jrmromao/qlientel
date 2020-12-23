using Application.DepartmentOps;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    public class ManagerProfileController : BaseController
    {
        //get department

        [HttpGet("department/{id}")]
        public async Task<ActionResult<DepartmentDto>> UpdateEmployee(Guid id) => await Mediator.Send(new Find.Query { Id = id });

        //get employees
    }
}