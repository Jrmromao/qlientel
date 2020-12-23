using Application.DepartmentOps;
using Application.Employee;
using Application.OfficeServices;
using Application.System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    public class SystemController : BaseController
    {
        [HttpGet("get-roles")]
        public async Task<ActionResult<List<ItemList>>> GetRoles() =>
            await Mediator.Send(new GetRoles.Query());

        // GET Offices
        [HttpGet("get-offices/{employeeID}")]
        public async Task<ActionResult<List<ItemList>>> GetOffices(Guid employeeID) =>
            await Mediator.Send(new FindAll.Query { EmployeeID = employeeID });

        //GET - all users who don't have user as the role
        [HttpGet("get-non-basic-users/{companyId}")]
        public async Task<ActionResult<List<ItemList>>> GetNonBasicUsers(Guid companyId) =>
            await Mediator.Send(new ListManagers.Query { CompantId = companyId });




        //GET - all users who don't have user as the role
        [HttpGet("get-departments-by-office/{officeId}")]
        public async Task<ActionResult<List<ItemList>>> GetDepartmentsByOffice(Guid officeId) =>
            await Mediator.Send(new FindAllDepartments.Query { OfficeId = officeId });

        //GET - list all job titles for company Id
        [HttpGet("list-job-titles/{companyId}")]
        public async Task<ActionResult<List<ItemList>>> ListJobTitles(Guid companyId) =>
            await Mediator.Send(new Application.JobTitleServices.List.Query { CompanyId = companyId });

        //PUT - create job title for company

        [HttpPost("create-job-titles")]
        [Authorize(Policy = "IsAdmin")]
        public async Task<ActionResult<Unit>> CreateJobTitles(Application.JobTitleServices.Create.Command command) =>
            await Mediator.Send(command);

        //PUT - update job title for a company
        [HttpPut("update-job-title/{jobTitleId}")]
        public async Task<ActionResult<Unit>> UpdateJobTitles(Guid jobTitleId,
            Application.JobTitleServices.Update.Command command)
        {
            command.JobTitileId = jobTitleId;
            return await Mediator.Send(command);

        }
        //GET - list all the policies by companyId
        [HttpPost("create-schedule-policy")]
        [Authorize(Policy = "IsAdmin")]
        public async Task<ActionResult<Unit>> CreateSchedulePolicy(Application.SchedulePolicyServices.Create.Command command) =>
            await Mediator.Send(command);

        //GET - create a policy for a company
        [HttpGet("list-schedule-policy/{companyId}")]
        [Authorize(Policy = "IsAdmin")]
        public async Task<ActionResult<List<ItemList>>> ListSchedulePolicy(Guid companyId) =>
            await Mediator.Send(new Application.SchedulePolicyServices.List.Query { CompanyId = companyId });


        [HttpPut("update-schedule-policy/{schedulePolicyId}")]
        public async Task<ActionResult<Unit>> UpdateSchedulePolicy(Guid schedulePolicyId,
            Application.SchedulePolicyServices.Update.Command command)
        {
            command.SchedulePolicyId = schedulePolicyId;
            return await Mediator.Send(command);
        }
    }
}