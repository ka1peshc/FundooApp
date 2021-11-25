using FundooModels;
using FundooRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public class NotesManager : INotesManager
    {
        private readonly INotesRepository NotesRepository;

        public NotesManager(INotesRepository repository)
        {
            this.NotesRepository = repository;
        }

        public async Task<string> CheckCreateNotes(NotesModel noteData)
        {
            try
            {
                return await this.NotesRepository.CreateNote(noteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> EditNote(NotesModel noteData)
        {
            try
            {
                return await this.NotesRepository.EditNote(noteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> EditIsArchive(NotesModel noteData)
        {
            try{    return await this.NotesRepository.EditIsArchive(noteData);}
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> EditIsTrash(NotesModel noteData)
        {
            try { return await this.NotesRepository.EditIsTrash(noteData); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> EditIsPin(NotesModel noteData)
        {
            try { return await this.NotesRepository.EditIsPin(noteData); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> EditColor(NotesModel noteData)
        {
            try { return await this.NotesRepository.EditColor(noteData); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> EditRemindMe(NotesModel noteData)
        {
            try { return await this.NotesRepository.EditRemindMe(noteData); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> EditAddImage(NotesModel noteData)
        {
            try { return await this.NotesRepository.EditAddImage(noteData); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NotesModel> GetAllNotes(int userid)
        {
            try { return this.NotesRepository.GetAllNotes(userid); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NotesModel> GetArchiveNotes(bool archive)
        {
            try { return this.NotesRepository.GetArchiveNotes(archive); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<NotesModel> GetTrashNotes(bool trash)
        {
            try { return this.NotesRepository.GetArchiveNotes(trash); }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
