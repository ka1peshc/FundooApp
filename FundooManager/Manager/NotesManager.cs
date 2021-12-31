// <copyright file="NotesManager.cs" company="JoyBoy">
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
    public class NotesManager : INotesManager
    {
        /// <summary>
        /// private declaration of NotesRepository
        /// </summary>
        private readonly INotesRepository notesRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesManager"/> class
        /// </summary>
        /// <param name="repository">notesRepository</param>
        public NotesManager(INotesRepository repository)
        {
            this.notesRepository = repository;
        }

        /// <summary>
        /// Checking input for create note
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> CheckCreateNotes(NotesModel noteData)
        {
            try
            {
                return await this.notesRepository.CreateNote(noteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checking input for edit note
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditNote(NotesModel noteData)
        {
            try
            {
                return await this.notesRepository.EditNote(noteData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checking input for edit IsArchive
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditIsArchive(int noteId)
        {
            try
            {
                return await this.notesRepository.EditIsArchive(noteId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Checking input for edit IsTrash
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditIsTrash(int noteId)
        {
            try 
            { 
                return await this.notesRepository.EditIsTrash(noteId); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checking input for edit IsPin
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditIsPin(NotesModel noteData)
        {
            try 
            { 
                return await this.notesRepository.EditIsPin(noteData); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checking input for edit Color
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditColor(int noteId, string noteColor)
        {
            try 
            { 
                return await this.notesRepository.EditColor(noteId,noteColor); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checking input for RemindeMe
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditRemindMe(NotesModel noteData)
        {
            try 
            { 
                return await this.notesRepository.EditRemindMe(noteData); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Checking input for add image
        /// </summary>
        /// <param name="noteData">NotesModel</param>
        /// <returns>http response</returns>
        public async Task<string> EditAddImage(NotesModel noteData)
        {
            try 
            { 
                return await this.notesRepository.EditAddImage(noteData); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all notes
        /// </summary>
        /// <param name="userid">User id</param>
        /// <returns>http response</returns>
        public IEnumerable<NotesModel> GetAllNotes(int userid)
        {
            try 
            { 
                return this.notesRepository.GetAllNotes(userid); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all archive notes
        /// </summary>
        /// <param name="archive">boolean value archive</param>
        /// <returns>http response</returns>
        public IEnumerable<NotesModel> GetArchiveNotes(int userid)
        {
            try 
            { 
                return this.notesRepository.GetArchiveNotes(userid); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get all trash notes
        /// </summary>
        /// <param name="trash">boolean value trash</param>
        /// <returns>http response</returns>
        public IEnumerable<NotesModel> GetTrashNotes(int userid)
        {
            try 
            { 
                return this.notesRepository.GetTrashNotes(userid); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

