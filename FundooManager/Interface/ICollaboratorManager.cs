using FundooModels;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public interface ICollaboratorManager
    {
        Task<string> CreateCollaborator(CollaboratorModel collaborator);
    }
}