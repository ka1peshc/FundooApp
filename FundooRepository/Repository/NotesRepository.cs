using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FundooModels;
using FundooRepository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public class NotesRepository : INotesRepository
    {
        private readonly UserContext userContext;

        public NotesRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;

        }
        public IConfiguration Configuration { get; }

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

        public async Task<string> EditIsArchive(NotesModel noteData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    if (validNoteId.IsPin)
                    {
                        validNoteId.IsPin = false;
                    }
                    validNoteId.IsArchive = noteData.IsArchive;
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

        public async Task<string> EditIsTrash(NotesModel noteData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();
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
                    validNoteId.IsTrash = noteData.IsTrash;
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

        public async Task<string> EditColor(NotesModel noteData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.Color = noteData.Color;
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

        public IEnumerable<NotesModel> GetAllNotes(int userid)
        {
            try
            {
                List<NotesModel> tempList = new List<NotesModel>();
                IEnumerable<NotesModel> result;
                IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.UserID == userid select x;
                foreach(var note in notes)
                {
                    if(note.IsArchive == true && note.IsTrash == true)
                        tempList.Add(note);
                }
                result = tempList;

                return result;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NotesModel> GetArchiveNotes(bool archive)
        {
            try
            {
                IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.IsArchive == archive select x;
                return notes;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NotesModel> GetTrashNotes(bool trash)
        {
            try
            {
                
                IEnumerable<NotesModel> notes = from x in this.userContext.Notes where x.IsTrash == trash select x;
                return notes;
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
