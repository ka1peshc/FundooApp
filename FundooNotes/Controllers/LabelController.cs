// <copyright file="LabelController.cs" company="JoyBoy">
// Copyright (c) JoyBoy. All rights reserved.
// </copyright>

namespace FundooNotes.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooManager.Manager;
    using FundooModels;
    using Microsoft.AspNetCore.Mvc;
    using NLog;

    /// <summary>
    /// Handle Request and give response
    /// </summary>
    public class LabelController : ControllerBase
    {
        /// <summary>
        ///  Private declaration of LabelManager
        /// </summary>
        private readonly ILabelManager labelManager;

        /// <summary>
        /// Private declaration of Logger
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance for LabelManager and logger
        /// </summary>
        /// <param name="manager">LabelManager</param>
        /// <param name="log">Logger</param>
        public LabelController(ILabelManager manager, ILogger log)
        {
            this.labelManager = manager;
            this.logger = log;
        }

        /// <summary>
        /// Create label for one note
        /// </summary>
        /// <param name="labelData">LabelModel</param>
        /// <returns>http response</returns>
        [HttpPost]
        [Route("api/createLabelforNote")]
        public async Task<IActionResult> AddLabelToNote([FromBody] LabelModel labelData)
        {
            try
            {
                string result = await this.labelManager.AddLabelToNote(labelData);
                if (result == "Label added to note")
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
            catch (ArgumentNullException ex)
            {
                this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Creating label for account and not for particular note
        /// </summary>
        /// <param name="labelData">LabelModel</param>
        /// <returns>http response</returns>
        [HttpPost]
        [Route("api/labelforacc")]
        public async Task<IActionResult> Labelforacc([FromBody] LabelModel labelData)
        {
            try
            {
                string result = await this.labelManager.AddLabelToUserAcc(labelData);
                if (result == "Label added to account")
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
            catch (ArgumentNullException ex)
            {
                this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete label from all notes
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="labelText">label text</param>
        /// <returns>http response</returns>
        [HttpDelete]
        [Route("api/DeleteLabelFromAllNotes")]
        public async Task<IActionResult> DeleteLabelFromAllNotes(int userId, string labelText)
        {
            try
            {
                string result = await this.labelManager.DeleteLabelFromAllNotes(userId, labelText);
                if (result == "Label removed from all notes")
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
            catch (ArgumentNullException ex)
            {
                this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Remove label from note
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="noteId">Note id</param>
        /// <returns>http response</returns>
        [HttpDelete]
        [Route("api/RemoveLabelFromNote")]
        public async Task<IActionResult> RemoveLabelFromNote(int userId, int noteId)
        {
            try
            {
                string result = await this.labelManager.RemoveLabelFromNote(userId, noteId);
                if (result == "Label removed from one notes")
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
            catch (ArgumentNullException ex)
            {
                this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get all label for user
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>http response</returns>
        [HttpGet]
        [Route("api/GetAllLabel")]
        public IActionResult GetAllLabelForUser(int userId)
        {
            try
            {
                IEnumerable<LabelModel> result = this.labelManager.GetAllLabelForUser(userId);
                if ((int)result.Count() != 0)
                {
                    this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new { Status = true, Message = "Get result", Data = result });
                }
                else
                {
                    this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "count is 0" });
                }
            }
            catch (ArgumentNullException ex)
            {
                this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get notes by label tex
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="labeltext">label text</param>
        /// <returns>http response</returns>
        [HttpGet]
        [Route("api/GetNotesByLabel")]
        public IActionResult GetNotesbylabel(int userId, string labeltext)
        {
            try
            {
                IEnumerable<LabelModel> result = this.labelManager.GetNotesbylabel(userId, labeltext);
                if ((int)result.Count() != 0)
                {
                    this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new { Status = true, Message = "Get result", Data = result });
                }
                else
                {
                    this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "count is 0" });
                }
            }
            catch (ArgumentNullException ex)
            {
                this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Edit and save label text
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="lblName">label text</param>
        /// <param name="editlblName">edit label text</param>
        /// <returns>http response</returns>
        [HttpPut]
        [Route("api/UpdateLabel")]
        public async Task<IActionResult> UpdateLabel(int userId, string lblName, string editlblName)
        {
            try
            {
                string result = await this.labelManager.UpdateLabel(userId, lblName, editlblName);
                if (result == "Update Successful")
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
            catch (ArgumentNullException ex)
            {
                this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
