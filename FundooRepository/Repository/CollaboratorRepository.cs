using FundooModels;
using FundooRepository.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
    }
}
