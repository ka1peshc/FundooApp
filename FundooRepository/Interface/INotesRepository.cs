using FundooModels;
using Microsoft.Extensions.Configuration;

namespace FundooRepository.Repository
{
    public interface INotesRepository
    {
        IConfiguration Configuration { get; }

        string CreateNote(NotesModel noteData);
        string EditNote(NotesModel notesData);
        string EditIsArchive(NotesModel noteData);
        string EditIsTrash(NotesModel noteData);
        string EditIsPin(NotesModel noteData);
    }
}