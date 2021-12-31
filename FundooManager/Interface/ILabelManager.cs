using FundooModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public interface ILabelManager
    {
        Task<string> AddLabelToNote(LabelModel labelData);
        Task<string> AddLabelToUserAcc(LabelModel labelData);
        Task<string> DeleteLabelFromAllNotes(int userId, string labelText);
        Task<string> RemoveLabelFromNote(int userId, int noteId);
        IEnumerable<LabelModel> GetAllLabelForUser(int userId);
        IEnumerable<LabelModel> GetNotesbylabel(int userId, string labeltext);
        Task<string> UpdateLabel(int userId, string lblName, string editlblName);
    }
}