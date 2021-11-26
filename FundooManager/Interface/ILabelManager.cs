using FundooModels;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public interface ILabelManager
    {
        Task<string> AddLabelToNote(LabelModel labelData);
    }
}