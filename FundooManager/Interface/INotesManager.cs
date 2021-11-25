using FundooModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public interface INotesManager
    {
        Task<string> CheckCreateNotes(NotesModel noteData);
        Task<string> EditNote(NotesModel noteData);
        Task<string> EditIsArchive(NotesModel noteData);
        Task<string> EditIsTrash(NotesModel noteData);
        Task<string> EditIsPin(NotesModel noteData);
        Task<string> EditColor(NotesModel noteData);
        Task<string> EditRemindMe(NotesModel noteData);
        Task<string> EditAddImage(NotesModel noteData);
        IEnumerable<NotesModel> GetAllNotes(int userid);
        IEnumerable<NotesModel> GetArchiveNotes(bool archive);
        IEnumerable<NotesModel> GetTrashNotes(bool trash);
    }
}