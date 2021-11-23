using FundooModels;
using FundooRepository.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public string CreateNote(NotesModel noteData)
        {
            try
            {
                var validUser = this.userContext.User.Where(x => x.UserID == noteData.UserID).FirstOrDefault();
                if (validUser != null)
                {
                    if (noteData != null)
                    {
                        this.userContext.Add(noteData);
                        this.userContext.SaveChanges();
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

        public string EditNote(NotesModel notesData)
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
                    this.userContext.SaveChanges();
                    return "Successfully updated note";
                }
                return "Unsuccessful to update Note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditIsArchive(NotesModel noteData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.IsArchive = noteData.IsArchive;
                    this.userContext.Update(validNoteId);
                    this.userContext.SaveChanges();
                    return "Successfully archive note";
                }
                return "Unsuccessful to archive Note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditIsTrash(NotesModel noteData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.IsTrash = noteData.IsTrash;
                    this.userContext.Update(validNoteId);
                    this.userContext.SaveChanges();
                    return "Successfully trash note";
                }
                return "Unsuccessful to trash Note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditIsPin(NotesModel noteData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.IsPin = noteData.IsPin;
                    this.userContext.Update(validNoteId);
                    this.userContext.SaveChanges();
                    return "Successfully pin note";
                }
                return "Unsuccessful to pin Note";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditColor(NotesModel noteData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == noteData.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    validNoteId.Color = noteData.Color;
                    this.userContext.Update(validNoteId);
                    this.userContext.SaveChanges();
                    return "Successfully change color";
                }
                return "Unsuccessful to change color";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
