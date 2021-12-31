using FundooModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public interface INotesRepository
    {
        IConfiguration Configuration { get; }

        Task<string> CreateNote(NotesModel noteData);
        Task<string> EditNote(NotesModel notesData);
        Task<string> EditIsArchive(int noteId);
        Task<string> EditIsTrash(int noteId);
        Task<string> EditIsPin(NotesModel noteData);
        Task<string> EditColor(int noteId, string noteColor);
        Task<string> EditRemindMe(NotesModel noteData);
        Task<string> EditAddImage(NotesModel noteData);

        IEnumerable<NotesModel> GetAllNotes(int userid);
        IEnumerable<NotesModel> GetArchiveNotes(int userid);
        IEnumerable<NotesModel> GetTrashNotes(int userid);
        string UploadAndGetImageUrl(IFormFile fileUpload, HttpPostAttribute selboton);
    }
}