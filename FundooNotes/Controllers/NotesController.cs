// <copyright file="NotesController.cs" company="JoyBoy">
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
    /// Handle Request and give response related to user note
    /// </summary>
    public class NotesController : ControllerBase
    {
        /// <summary>
        /// Private declaration of NotesManager
        /// </summary>
        private readonly INotesManager notesManager;

        /// <summary>
        /// Private declaration of Logger class
        /// </summary>
        private readonly ILogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesController"/>
        /// </summary>
        /// <param name="log">Logger</param>
        /// <param name="manager">Notes Manager</param>
        //public NotesController(ILogger log, INotesManager manager)
        //{
        //    this.notesManager = manager;
        //    this.logger = log;
        //}
        public NotesController( INotesManager manager)
        {
            this.notesManager = manager;
        }

        /// <summary>
        /// create new note
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>Http response</returns>
        [HttpPost]
        [Route("api/createnote")]
        public async Task<IActionResult> CreateNote([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.CheckCreateNotes(noteData);
                if (result.Equals("Successfully created note"))
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Edit Note's title or body or both
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>Http response</returns>
        [HttpPut]
        [Route("api/editnote")]
        public async Task<IActionResult> EditNote([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.EditNote(noteData);
                if (result.Equals("Successfully updated note"))
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
        
        /// <summary>
        /// Edit is archive
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        [HttpPut]
        [Route("api/editIsArchive")]
        public async Task<IActionResult> EditIsArchive(int noteId)
        {
            try
            {
                string result = await this.notesManager.EditIsArchive(noteId);
                if (result.Equals("Successfully archive note"))
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Edit is trash
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        [HttpPut]
        [Route("api/editIsTrash")]
        public async Task<IActionResult> EditIsTrash(int noteId)
        {
            try
            {
                string result = await this.notesManager.EditIsTrash(noteId);
                if (result.Equals("Successfully trash note"))
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Edit is pin
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        [HttpPut]
        [Route("api/editIsPin")]
        public async Task<IActionResult> EditIsPin([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.EditIsPin(noteData);
                if (result.Equals("Successfully pin note"))
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Change color
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        [HttpPut]
        [Route("api/editColor")]
        public async Task<IActionResult> EditColor(int noteId, string noteColor)
        {
            try
            {
                string result = await this.notesManager.EditColor(noteId,noteColor);
                if (result.Equals("Successfully change color"))
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Add remide me
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>Http response</returns>
        [HttpPut]
        [Route("api/editRemindMe")]
        public async Task<IActionResult> EditRemindeMe([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.EditRemindMe(noteData);
                if (result.Equals("Successfully add reminder"))
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Add image
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        [HttpPut]
        [Route("api/editAddImage")]
        public async Task<IActionResult> EditAddImage([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.EditAddImage(noteData);
                if (result.Equals("Successfully add reminder"))
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get all notes
        /// </summary>
        /// <param name="userid">User id</param>
        /// <returns>Http response</returns>
        [HttpGet]
        [Route("api/getAllNotes")]
        public IActionResult GetAllNotes(int userid)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetAllNotes(userid);
                if ((int)result.Count() != 0)
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new { Status = true, Data = result });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No notes found" });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get all archive notes
        /// </summary>
        /// <param name="archive">Boolean archive</param>
        /// <returns>http response</returns>
        [HttpGet]
        [Route("api/getArchiveNotes")]
        public IActionResult GetArchiveNotes(int userid)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetArchiveNotes(userid);
                if ((int)result.Count() != 0)
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new { Status = true, Data = result });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No notes in Archive" });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        /// <summary>
        /// get trash notes
        /// </summary>
        /// <param name="trash">boolean trash</param>
        /// <returns>http response</returns>
        [HttpGet]
        [Route("api/getTrashNotes")]
        public IActionResult GetTrashNotes(int userid)
        {
            try
            {
                IEnumerable<NotesModel> result = this.notesManager.GetTrashNotes(userid);
                if ((int)result.Count() != 0)
                {
                    //this.logger.Info(result + Environment.NewLine + DateTime.Now);
                    return this.Ok(new { Status = true, Data = result });
                }
                else
                {
                    //this.logger.Warn(result + Environment.NewLine + DateTime.Now);
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No notes in trash" });
                }
            }
            catch (Exception ex)
            {
                //this.logger.Error(ex.Message + Environment.NewLine + DateTime.Now);
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
