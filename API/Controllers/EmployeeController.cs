using Application;
using Application.Employee;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// Controller to handle all the operations needed to undertake operations related to the company employee
    /// </summary>
    [AllowAnonymous]
    public class EmployeeController : BaseController
    {
        /// <summary>
        /// Method to add a new Employee
        /// </summary>
        /// <param name="command">Variables to Add a new Customer</param>
        /// <returns></returns>
        [HttpPost("add-employee")]
        public async Task<ActionResult<Unit>> AddEmployee([FromForm] Create.Command command) => await Mediator.Send(command);

        [HttpGet("get-details/{employeeId}")]
        public async Task<ActionResult<EmployeeDto>> GetDetails(string employeeId) => await Mediator.Send(new Get.Query { EmployeeId = employeeId });

        [HttpPut("update-employee/{emplyeeId}")]
        public async Task<ActionResult<Unit>> UpdateEmployee(string emplyeeId, Update.Command command)
        {
            command.Id = emplyeeId;
            return await Mediator.Send(command);
        }

        [HttpGet("get-leaves-data/{employeeId}")]
        public async Task<ActionResult<LeavesDto>> GetLeavesData(Guid employeeId) => await Mediator.Send(new GetLeaves.Query { EmployeeID = employeeId });

        /// <summary>
        ///
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("leave-request")]
        public async Task<ActionResult<Unit>> RequestLeave(RequestLeaves.Command command) => await Mediator.Send(command);
    }
}