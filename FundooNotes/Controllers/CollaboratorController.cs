using FundooManager.Manager;
using FundooModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class CollaboratorController : ControllerBase
    {
        private readonly ICollaboratorManager collaboratorManager;

        public CollaboratorController(ICollaboratorManager manager)
        {
            this.collaboratorManager = manager;
        }

        [HttpPost]
        [Route("api/createCollaborator")]
        public async Task<IActionResult> CreateCollaborator([FromBody] CollaboratorModel collaboratorData)
        {
            try
            {
                string result = await this.collaboratorManager.CreateCollaborator(collaboratorData);
                if (result.Equals("Collaborator created successful"))
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
