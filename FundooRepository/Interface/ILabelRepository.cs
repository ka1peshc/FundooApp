using FundooModels;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public interface ILabelRepository
    {
        IConfiguration Configuration { get; }

        Task<string> AddLabelToNote(LabelModel labelData);
        Task<string> AddLabelToAccount(LabelModel labelData);
    }
}