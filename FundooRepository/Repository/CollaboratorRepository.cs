using FundooModels;
using FundooRepository.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly UserContext userContext;

        public CollaboratorRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;

        }
        public IConfiguration Configuration { get; }
        public async Task<string> CreateCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                if (collaborator != null)
                {
                    this.userContext.Add(collaborator);
                    await this.userContext.SaveChangesAsync();
                    return "Collaborator created successful";
                }
                return "Unsuccessful to create collaborator";
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<string> DeleteCollaborator(int collaborator)
        {
            try
            {
                var checkCollabId = this.userContext.Collaborator.Where(x => x.CollaboratorID == collaborator).FirstOrDefault();
                if (checkCollabId != null)
                {
                    if (collaborator != 0)
                    {
                        this.userContext.Remove(checkCollabId);
                        await this.userContext.SaveChangesAsync();
                        return "Successfully removed collaborator";
                    }
                    return "Collaborator body is null";
                }
                return "Collabortor id doesnot exist";
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public List<string> GetEmailName(int noteId)
        {
            try
            {
                List<string> emails = new List<string>();
                var checkIfNoteExit = this.userContext.Collaborator.Where(x => x.NoteId == noteId).FirstOrDefault();
                if (checkIfNoteExit != null)
                {
                    IEnumerable<CollaboratorModel> getEmailList = from x in this.userContext.Collaborator where x.NoteId == noteId select x;
                    foreach (var email in getEmailList)
                    {
                        string result = email.CollaboratorID + " " + email.NoteId + " " + email.EmailId;
                        emails.Add(result);
                    }

                }
                return emails;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
