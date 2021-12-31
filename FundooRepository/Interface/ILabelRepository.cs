using FundooModels;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public interface ILabelRepository
    {
        IConfiguration Configuration { get; }

        Task<string> AddLabelToNote(LabelModel labelData);
        Task<string> AddLabelToUserAcc(LabelModel labelData);
        Task<string> DeleteLabelFromAllNotes(int userId, string labelText);
        Task<string> RemoveLabelFromNote(int userId, int noteId);
        IEnumerable<LabelModel> GetAllLabelForUser(int userId);
        IEnumerable<LabelModel> GetNotesbylabel(int userId, string labeltext);
        Task<string> UpdateLabel(int userId, string lblName, string editlblName);
    }
}