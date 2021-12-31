// <copyright file="LabelManager.cs" company="JoyBoy">
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
    public class LabelManager : ILabelManager
    {
        /// <summary>
        /// private declaration of LabelRepository
        /// </summary>
        private readonly ILabelRepository labelRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelManager"/> class
        /// </summary>
        /// <param name="repository">LabelRepository</param>
        public LabelManager(ILabelRepository repository)
        {
            this.labelRepository = repository;
        }

        /// <summary>
        /// Check input that required for creating label
        /// </summary>
        /// <param name="labelData">LabelModel</param>
        /// <returns>http response</returns>
        public async Task<string> AddLabelToNote(LabelModel labelData)
        {
            try
            {
                return await this.labelRepository.AddLabelToNote(labelData);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// checking input for add label to user account
        /// </summary>
        /// <param name="labelData">LabelModel</param>
        /// <returns>http response</returns>
        public async Task<string> AddLabelToUserAcc(LabelModel labelData)
        {
            try
            {
                return await this.labelRepository.AddLabelToUserAcc(labelData);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// checking input for delete label from all notes
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="labelText">Label text</param>
        /// <returns>http response</returns>
        public async Task<string> DeleteLabelFromAllNotes(int userId, string labelText)
        {
            try
            {
                return await this.labelRepository.DeleteLabelFromAllNotes(userId, labelText);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Checking input for removing label from a note
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="noteId">note id</param>
        /// <returns>http response</returns>
        public async Task<string> RemoveLabelFromNote(int userId, int noteId)
        {
            try
            {
                return await this.labelRepository.RemoveLabelFromNote(userId, noteId);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Checking input for get all label for user
        /// </summary>
        /// <param name="userId">user id</param>
        /// <returns>http response</returns>
        public IEnumerable<LabelModel> GetAllLabelForUser(int userId)
        {
            try
            {
                return this.labelRepository.GetAllLabelForUser(userId);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// Checking input for get notes using label text
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="labeltext">label text</param>
        /// <returns>http response</returns>
        public IEnumerable<LabelModel> GetNotesbylabel(int userId, string labeltext)
        {
            try
            {
                return this.labelRepository.GetNotesbylabel(userId, labeltext);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        /// <summary>
        /// checking input for update label
        /// </summary>
        /// <param name="userId">user id</param>
        /// <param name="lblName">label text</param>
        /// <param name="editlblName">change to label text</param>
        /// <returns>http response</returns>
        public async Task<string> UpdateLabel(int userId, string lblName, string editlblName)
        {
            try
            {
                return await this.labelRepository.UpdateLabel(userId, lblName, editlblName);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
