using FundooModels;
using FundooRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public class CollaboratorManager : ICollaboratorManager
    {
        private readonly ICollaboratorRepository CollaboratorRepository;

        public CollaboratorManager(ICollaboratorRepository repository)
        {
            this.CollaboratorRepository = repository;
        }

        public async Task<string> CreateCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                return await this.CollaboratorRepository.CreateCollaborator(collaborator);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> DeleteCollaborator(int collaborator)
        {
            try
            {
                return await this.CollaboratorRepository.DeleteCollaborator(collaborator);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<string> GetEmails(int emailId)
        {
            try
            {
                return this.CollaboratorRepository.GetEmailName(emailId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
