﻿using FundooManager.Manager;
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
        public IActionResult CreateNote([FromBody] NotesModel noteData)
        {
            try
            {
                string result = this.notesManager.CheckCreateNotes(noteData);
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
    }
}
