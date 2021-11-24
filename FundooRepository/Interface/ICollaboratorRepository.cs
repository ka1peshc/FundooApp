﻿using FundooModels;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace FundooRepository.Repository
{
    public interface ICollaboratorRepository
    {
        IConfiguration Configuration { get; }

        Task<string> CreateCollaborator(CollaboratorModel collaborator);
        Task<string> DeleteCollaborator(int collaborator);
    }
}