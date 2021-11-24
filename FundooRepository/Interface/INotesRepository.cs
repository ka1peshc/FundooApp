using FundooModels;
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

        List<string> GetAllNotes(int userid);
        List<string> GetArchiveNotes(int userid);
        List<string> GetTrashNotes(int userid);
    }
}