// <copyright file="NotesRepository.cs" company="JoyBoy">
// Copyright (c) JoyBoy. All rights reserved.
// </copyright>

namespace FundooRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using FundooModels;
    using FundooRepository.Context;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Interact with Notes table
    /// </summary>
    public class NotesRepository : INotesRepository
    {
        /// <summary>
        /// private declaration of UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesRepository"/> class
        /// </summary>
        /// <param name="configuration">Configuration</param>
        /// <param name="userContext">UserContext</param>
        public NotesRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;
        }

        /// <summary>
        /// Gets configuration from project
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Create a new note
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> CreateNote(NotesModel noteData)
        {
            try
            {
                var validUser = this.userContext.User.Where(x => x.UserID == noteData.UserID).FirstOrDefault();
                if (validUser != null)
                {
                    if (noteData != null)
                    {
                        this.userContext.Add(noteData);
                        await this.userContext.SaveChangesAsync();
                        return "Successfully created note";
                    }

                }
                return "Unsuccessful to create Note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Change title or body or both
        /// </summary>
        /// <param name="notesData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditNote(NotesModel notesData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == notesData.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    if (notesData.Title == null && notesData.Body != null)
                    {
                        validNoteId.Body = notesData.Body;
                    }
                    else if (notesData.Title != null && notesData.Body == null) 
                    {
                        validNoteId.Title = notesData.Title;
                    }
                    else
                    {
                        validNoteId.Title = notesData.Title;
                        validNoteId.Body = notesData.Body;
                    }
                    
                    this.userContext.Update(validNoteId);
                    await this.userContext.SaveChangesAsync();
                    return "Successfully updated note";
                }
                return "Unsuccessful to update Note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// move to archive
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditIsArchive(int noteId)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    if (validNoteId.IsPin)
                    {
                        validNoteId.IsPin = false;

                    }
                    validNoteId.IsArchive = true;
                    this.userContext.Update(validNoteId);
                    await this.userContext.SaveChangesAsync();
                    return "Successfully archive note";

                }
                return "Unsuccessful to archive Note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// move to trash
        /// </summary>
        /// <param name="noteData"></param>
        /// <returns></returns>
        public async Task<string> EditIsTrash(int noteId)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    if(validNoteId.IsPin)
                    {
                        validNoteId.IsPin = false;
                    }
                    if (validNoteId.IsArchive)
                    {
                        validNoteId.IsArchive = false;
                    }
                    validNoteId.IsTrash = true;
                    this.userContext.Update(validNoteId);
                    await this.userContext.SaveChangesAsync();
                    return "Successfully trash note";
                }
                return "Unsuccessful to trash Note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Set Pin
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditIsPin(NotesModel noteData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.IsPin = noteData.IsPin;
                    this.userContext.Update(validNoteId);
                    await this.userContext.SaveChangesAsync();
                    return "Successfully pin note";
                }
                return "Unsuccessful to pin Note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Setting background color for note
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditColor(int noteId,string noteColor)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.Color = noteColor;
                    this.userContext.Update(validNoteId);
                    await this.userContext.SaveChangesAsync();
                    return "Successfully change color";
                }
                return "Unsuccessful to change color";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add Reminde me
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditRemindMe(NotesModel noteData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.RemindMe = noteData.RemindMe;
                    this.userContext.Update(validNoteId);
                    await this.userContext.SaveChangesAsync();
                    return "Successfully add reminder";
                }
                return "Unsuccessful to add reminder";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Add image to note
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditAddImage(NotesModel noteData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.AddImage = noteData.AddImage;
                    this.userContext.Update(validNoteId);
                    await this.userContext.SaveChangesAsync();
                    return "Successfully add reminder";
                }
                return "Unsuccessful to add reminder";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all notes
        /// </summary>
        /// <param name="userid">user id</param>
        /// <returns>http response</returns>
        public IEnumerable<NotesModel> GetAllNotes(int userid)
        {
            try
            {
                List<NotesModel> tempList = new List<NotesModel>();
                IEnumerable<NotesModel> result;
                //IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.UserID == userid select x;
                IEnumerable<NotesModel> notes = from notetb in this.userContext.Notes
                                                where notetb.UserID == userid && notetb.IsArchive == false && notetb.IsTrash == false
                                                select notetb;
                //foreach (var note in notes)
                //{
                //    if (note.IsArchive == true && note.IsTrash == true && note.UserID == userid)
                //    {
                //        tempList.Add(note);
                //    }       
                //}
                //result = tempList;
                if(notes != null)
                {
                    return notes;
                }
                return null;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get notes which are in archive
        /// </summary>
        /// <param name="archive">boolean archive</param>
        /// <returns>http response</returns>
        public IEnumerable<NotesModel> GetArchiveNotes(int userid)
        {
            try
            {
                IEnumerable<NotesModel> notes = from notetb in this.userContext.Notes
                                                where notetb.UserID == userid && notetb.IsArchive == true
                                                select notetb;
                return notes;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// get notes which are in trash
        /// </summary>
        /// <param name="trash">boolean trash</param>
        /// <returns>http response</returns>
        public IEnumerable<NotesModel> GetTrashNotes(int userid)
        {
            try
            {

                IEnumerable<NotesModel> notes = from notetb in this.userContext.Notes
                                                where notetb.UserID == userid && notetb.IsTrash == true
                                                select notetb;
                return notes;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Upload to cloudinary website
        /// </summary>
        /// <param name="fileUpload">file path from user</param>
        /// <param name="selboton">I dont know</param>
        /// <returns>http response</returns>
        public string UploadAndGetImageUrl(IFormFile fileUpload, HttpPostAttribute selboton)
        {
            var cloudinary = new Cloudinary(
            new Account(
            "dgofsupp6",
            "876618241945163",
            "Rnh7j0-QEbWWyqUcoPI0CDpUEWA"));

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileUpload.FileName, fileUpload.OpenReadStream()),
            };

            var uploadResult = cloudinary.Upload(uploadParams);

            var uplPath = uploadResult.Url;
            return uplPath.ToString();
        }
    }
}
