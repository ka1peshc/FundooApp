using FundooModels;
using FundooRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository NotesRepository;

        public NotesManager(INotesRepository repository)
        {
            this.NotesRepository = repository;
        }

        public string CheckCreateNotes(NotesModel noteData)
        {
            try
            {
                return this.NotesRepository.CreateNote(noteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditNote(EditNoteModel noteData)
        {
            try
            {
                return this.NotesRepository.EditNote(noteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
