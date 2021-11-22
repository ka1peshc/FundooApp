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

        public string EditNote(EditNoteModel notesData)
        {
            try
            {
                var validNoteId = this.userContext.Notes.Where(x => x.NoteId == notesData.NoteId).FirstOrDefault();
                if (validNoteId != null)
                {
                    if (notesData != null)
                    {
                        this.userContext.Update(validNoteId);
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
    }
}
