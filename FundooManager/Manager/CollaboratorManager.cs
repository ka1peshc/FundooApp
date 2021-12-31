// <copyright file="CollaboratorManager.cs" company="JoyBoy">
// Copyright (c) JoyBoy. All rights reserved.
// </copyright>

namespace FundooManager.Manager
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooModels;
    using FundooRepository.Repository;

    /// <summary>
    /// Check input from repository class and send it to controller
    /// </summary>
    public class CollaboratorManager : ICollaboratorManager
    {
        /// <summary>
        /// private declaration of LabelRepository
        /// </summary>
        private readonly ICollaboratorRepository collaboratorRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorManager"/> class
        /// </summary>
        /// <param name="repository">CollaboratorRepository</param>
        public CollaboratorManager(ICollaboratorRepository repository)
        {
            this.collaboratorRepository = repository;
        }

        /// <summary>
        /// Checking input for creating Collaborator
        /// </summary>
        /// <param name="collaborator">CollaboratorModel</param>
        /// <returns>http response</returns>
        public async Task<string> CreateCollaborator(CollaboratorModel collaborator)
        {
            try
            {
                return await this.collaboratorRepository.CreateCollaborator(collaborator);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checking input for delete collaborator
        /// </summary>
        /// <param name="collaborator">collaborator</param>
        /// <returns>http response</returns>
        public async Task<string> DeleteCollaborator(int collaborator)
        {
            try
            {
                return await this.collaboratorRepository.DeleteCollaborator(collaborator);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checking input for get email
        /// </summary>
        /// <param name="emailId">email id</param>
        /// <returns>http response</returns>
        public List<string> GetEmails(int emailId)
        {
            try
            {
                return this.collaboratorRepository.GetEmailName(emailId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
