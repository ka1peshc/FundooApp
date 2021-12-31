using FundooModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public interface INotesManager
    {
        Task<string> CheckCreateNotes(NotesModel noteData);
        Task<string> EditNote(NotesModel noteData);
        Task<string> EditIsArchive(int noteId);
        Task<string> EditIsTrash(int noteId);
        Task<string> EditIsPin(NotesModel noteData);
        Task<string> EditColor(int noteId, string noteColor);
        Task<string> EditRemindMe(NotesModel noteData);
        Task<string> EditAddImage(NotesModel noteData);
        IEnumerable<NotesModel> GetAllNotes(int userid);
        IEnumerable<NotesModel> GetArchiveNotes(int userid);
        IEnumerable<NotesModel> GetTrashNotes(int userid);
    }
}