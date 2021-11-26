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
        Task<string> EditIsArchive(NotesModel noteData);
        Task<string> EditIsTrash(NotesModel noteData);
        Task<string> EditIsPin(NotesModel noteData);
        Task<string> EditColor(NotesModel noteData);
        Task<string> EditRemindMe(NotesModel noteData);
        Task<string> EditAddImage(NotesModel noteData);

        IEnumerable<NotesModel> GetAllNotes(int userid);
        IEnumerable<NotesModel> GetArchiveNotes(bool archive);
        IEnumerable<NotesModel> GetTrashNotes(bool trash);
        string UploadAndGetImageUrl(IFormFile fileUpload, HttpPostAttribute selboton);
    }
}