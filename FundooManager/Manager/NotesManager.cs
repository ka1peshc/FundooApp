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

        public string EditNote(NotesModel noteData)
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

        public string EditIsArchive(NotesModel noteData)
        {
            try{    return this.NotesRepository.EditIsArchive(noteData);}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string EditIsTrash(NotesModel noteData)
        {
            try { return this.NotesRepository.EditIsTrash(noteData); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditIsPin(NotesModel noteData)
        {
            try { return this.NotesRepository.EditIsPin(noteData); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditColor(NotesModel noteData)
        {
            try { return this.NotesRepository.EditColor(noteData); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditRemindMe(NotesModel noteData)
        {
            try { return this.NotesRepository.EditRemindMe(noteData); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string EditAddImage(NotesModel noteData)
        {
            try { return this.NotesRepository.EditAddImage(noteData); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
