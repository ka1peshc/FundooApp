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

        [HttpDelete]
        [Route("api/deleteCollaborator")]
        public async Task<IActionResult> DeleteCollaborator(int collaboratorData)
        {
            try
            {
                string result = await this.collaboratorManager.DeleteCollaborator(collaboratorData);
                if (result.Equals("Successfully removed collaborator"))
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

        [HttpGet]
        [Route("api/getEmails")]
        public IActionResult GetEmails(int noteid)
        {
            try
            {
                List<string> result = this.collaboratorManager.GetEmails(noteid);
                if (result.Count != 0)
                {
                    return this.Ok(new { Status = true, Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
