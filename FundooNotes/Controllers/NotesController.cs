using FundooManager.Manager;
using FundooModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class NotesController : ControllerBase
    {
        private readonly INotesManager notesManager;

        public NotesController(INotesManager manager)
        {
            this.notesManager = manager;
        }

        [HttpPost]
        [Route("api/createnote")]
        public async Task<IActionResult> CreateNote([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.CheckCreateNotes(noteData);
                if (result.Equals("Successfully created note"))
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

        [HttpPut]
        [Route("api/editnote")]
        public async Task<IActionResult> EditNote([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.EditNote(noteData);
                if (result.Equals("Successfully updated note"))
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
        [HttpPut]
        [Route("api/editIsArchive")]
        public async Task<IActionResult> EditIsArchive([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.EditIsArchive(noteData);
                if (result.Equals("Successfully archive note"))
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

        [HttpPut]
        [Route("api/editIsTrash")]
        public async Task<IActionResult> EditIsTrash([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.EditIsTrash(noteData);
                if (result.Equals("Successfully trash note"))
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

        [HttpPut]
        [Route("api/editIsPin")]
        public async Task<IActionResult> EditIsPin([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.EditIsPin(noteData);
                if (result.Equals("Successfully pin note"))
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

        [HttpPut]
        [Route("api/editColor")]
        public async Task<IActionResult> EditColor([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.EditColor(noteData);
                if (result.Equals("Successfully change color"))
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

        [HttpPut]
        [Route("api/editRemindMe")]
        public async Task<IActionResult> EditRemindMe([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.EditRemindMe(noteData);
                if (result.Equals("Successfully add reminder"))
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

        [HttpPut]
        [Route("api/editAddImage")]
        public async Task<IActionResult> EditAddImage([FromBody] NotesModel noteData)
        {
            try
            {
                string result = await this.notesManager.EditAddImage(noteData);
                if (result.Equals("Successfully add reminder"))
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
        [Route("api/getAllNotes")]
        public IActionResult GetAllNotes(int userid)
        {
            try
            {
                List<string> result = this.notesManager.GetAllNotes(userid);
                if(result.Count != 0)
                {
                    return this.Ok(new { Status = true, Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No notes found" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/getArchiveNotes")]
        public IActionResult GetArchiveNotes(int userid)
        {
            try
            {
                List<string> result = this.notesManager.GetArchiveNotes(userid);
                if (result.Count != 0)
                {
                    return this.Ok(new { Status = true, Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No notes in Archive" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/getTrashNotes")]
        public IActionResult GetTrashNotes(int userid)
        {
            try
            {
                List<string> result = this.notesManager.GetTrashNotes(userid);
                if (result.Count != 0)
                {
                    return this.Ok(new { Status = true, Data = result });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = "No notes in trash" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
