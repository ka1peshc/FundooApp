// <copyright file="NotesRepository.cs" company="JoyBoy">
// Copyright (c) JoyBoy. All rights reserved.
// </copyright>

namespace FundooRepository.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using FundooModels;
    using FundooRepository.Context;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Interact with Collaborator table
    /// </summary>
    public class CollaboratorRepository : ICollaboratorRepository
    {
        /// <summary>
        /// private declaration of UserContext
        /// </summary>
        private readonly UserContext userContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorRepository"/> class
        /// </summary>
        /// <param name="configuration">Configuration</param>
        /// <param name="userContext">UserContext</param>
        public CollaboratorRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;

        }

        /// <summary>
        /// Gets configuration from project
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Create a collaborator
        /// </summary>
        /// <param name="collaborator">CollaboratorModel</param>
        /// <returns>http response</returns>
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

        /// <summary>
        /// Delete whole collaborator
        /// </summary>
        /// <param name="collaborator">collaborator id</param>
        /// <returns>http response</returns>
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

        /// <summary>
        /// Get email related to collaborator
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>http response</returns>
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
