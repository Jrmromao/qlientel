using Application.CompanyFunc;
using Application.DepartmentOps;
using Application.OfficeServices;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [AllowAnonymous]
    public class AdminController : BaseController
    {
        //POST - register new offices
        [HttpPost("add-office")]
        public async Task<ActionResult<Unit>> AddOffice(CreateOffice.Command command)
        => await Mediator.Send(command);

        //PUT - update office details
        [HttpPut("update-office-details/{officeID}")]
        public async Task<ActionResult<Unit>> UpdateOfficeDetails(string officeId)
        => await Mediator.Send(new UpdateOffice.Command { OfficeId = officeId });

        //GET - get office details
        [HttpGet("get-office-details/{officeID}")]
        public async Task<ActionResult<OfficeDto>> GetOfficeDetails(string officeId)
        => await Mediator.Send(new FindOffice.Query { OfficeId = officeId });

        //DELETE
        // to be added at later stage

        //POST - register department for each office
        [HttpPost("add-department")]
        public async Task<ActionResult<Unit>> AddDepartment(CreateDepartment.Command command)
        => await Mediator.Send(command);

        // employees for a given company
        //GET - get office details
        [HttpGet("get-company-employees/{companyId}")]
        public async Task<ActionResult<List<EmployeeDetailsDto>>> GetCompanyEmployees(Guid companyId)
         => await Mediator.Send(new GetAll.Query {CompanyId = companyId });

        [HttpGet("get-company-details/{employeeId}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(Guid employeeId)
        => await Mediator.Send(new FindCompany.Query { EmployeeId = employeeId });

        /**
         *
         * an admin can do what the manager does plus everything else
         * a manager can only read or write data to his department.
         *
         *
         * **/
    }
}