using FundooModels;

namespace FundooManager.Manager
{
    public interface INotesManager
    {
        string CheckCreateNotes(NotesModel noteData);
        string EditNote(NotesModel noteData);
        string EditIsArchive(NotesModel noteData);
        string EditIsTrash(NotesModel noteData);
        string EditIsPin(NotesModel noteData);
        string EditColor(NotesModel noteData);
        string EditRemindMe(NotesModel noteData);
    }
}