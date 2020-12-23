using Application.CompanyFunc;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class CompanyController : BaseController
    {


        /// <summary>
        /// Register a new company in the system. The user been used to register this new company, will be registered 
        /// as supper Administrator.
        /// </summary>
        /// <param name="command">Object with company and user details</param>
        /// <returns>  If successfully this method will return a Unit else throw an Error. </returns>
        //POST - add-company
        [HttpPost("add-company")]
        [AllowAnonymous]
        public async Task<ActionResult<Unit>> AddCompanyData(Create.Command command)
            => await Mediator.Send(command);

        ////GET - find-company/{id}
        //[HttpGet("find-company/{id}")]    
        //[AllowAnonymous]
        //public async Task<ActionResult<CompanyDto>> FindCompanyById(Guid id)
        //    => await Mediator.Send(new Find.Query { Id = id });
    }
}