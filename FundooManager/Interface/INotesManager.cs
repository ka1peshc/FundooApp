using FundooModels;

namespace FundooManager.Manager
{
    public interface INotesManager
    {
        string CheckCreateNotes(NotesModel noteData);
        string EditNote(EditNoteModel noteData);
    }
}