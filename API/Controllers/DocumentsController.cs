using Application.AzureServices;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    /// <summary>
    /// Controller to handle the operations needed to undertake the document operations
    /// </summary>
    public class DocumentsController : BaseController
    {
        /// <summary>
        /// Submit a single document to the system
        /// </summary>
        /// <param name="command"></param>
        /// <returns>If operation is successful, return an unit value</returns>
        [HttpPost]
        public async Task<ActionResult<Unit>> Add([FromForm] AddDocument.Command command) =>
            await Mediator.Send(command);

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Unit>> Delete(string id)
        //{
        //    return await Mediator.Send(new Delete.Command { Id = id });
        //}

        //[HttpPost("{id}/setmain")]
        //public async Task<ActionResult<Unit>> SetMain(string id)
        //{
        //    return await Mediator.Send(new SetMain.Command { Id = id });
    }
}
