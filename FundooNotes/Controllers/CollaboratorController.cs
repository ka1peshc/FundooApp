// <copyright file="CollaboratorController.cs" company="JoyBoy">
// Copyright (c) JoyBoy. All rights reserved.
// </copyright>

namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooManager.Manager;
    using FundooModels;
    using Microsoft.AspNetCore.Mvc;
    using NLog;

    /// <summary>
    /// Handle Request and give response
    /// </summary>
    public class CollaboratorController : ControllerBase
    {
        /// <summary>
        /// Private declaration of CollaboratorManager
        /// </summary>
        private readonly ICollaboratorManager collaboratorManager;
        
        /// <summary>
        /// Private declaration of Logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance for CollaboratorManager and logger
        /// </summary>
        /// <param name="manager">CollaboratorManager</param>
        /// <param name="log">Logger</param>
        public CollaboratorController(ICollaboratorManager manager, ILogger log)
        {
            this.collaboratorManager = manager;
            this.logger = log;
        }

        /// <summary>
        /// Create new collaborator
        /// </summary>
        /// <param name="collaboratorData">CollaboratorModel</param>
        /// <returns>Http Response</returns>
        [HttpPost]
        [Route("api/createCollaborator")]
        public async Task<IActionResult> CreateCollaborator([FromBody] CollaboratorModel collaboratorData)
        {
            try
            {
                string result = await this.collaboratorManager.CreateCollaborator(collaboratorData);
                if (result.Equals("Collaborator created successful"))
                {
                    this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete whole collaborator
        /// </summary>
        /// <param name="collaboratorData">Collaborator id</param>
        /// <returns>http response</returns>
        [HttpDelete]
        [Route("api/deleteCollaborator")]
        public async Task<IActionResult> DeleteCollaborator(int collaboratorData)
        {
            try
            {
                string result = await this.collaboratorManager.DeleteCollaborator(collaboratorData);
                if (result.Equals("Successfully removed collaborator"))
                {
                    this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get collaborator email
        /// </summary>
        /// <param name="noteid">Note id</param>
        /// <returns>Response</returns>
        [HttpGet]
        [Route("api/getEmails")]
        public IActionResult GetEmails(int noteid)
        {
            try
            {
                List<string> result = this.collaboratorManager.GetEmails(noteid);
                if (result.Count != 0)
                {
                    this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new { Status = true, Data = result });
                }
                else
                {
                    this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "Failed" });
                }
            }
            catch (Exception ex)
            {
                this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
