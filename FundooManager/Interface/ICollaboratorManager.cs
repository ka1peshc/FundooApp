using FundooModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public interface ICollaboratorManager
    {
        Task<string> CreateCollaborator(CollaboratorModel collaborator);
        Task<string> DeleteCollaborator(int collaborator);
        List<string> GetEmails(int emailId);
    }
}