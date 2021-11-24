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
        List<string> GetAllNotes(int userid);
        List<string> GetArchiveNotes(int userid);
        List<string> GetTrashNotes(int userid);
    }
}