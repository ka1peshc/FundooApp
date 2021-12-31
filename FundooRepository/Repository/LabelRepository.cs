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
    public class LabelRepository : ILabelRepository
    {
        private readonly UserContext userContext;

        public LabelRepository(IConfiguration configuration, UserContext userContext)
        {
            this.Configuration = configuration;
            this.userContext = userContext;

        }
        public IConfiguration Configuration { get; }

        public async Task<string> AddLabelToNote(LabelModel labelData)
        {
            try
            {
                var validlabel = this.userContext.Labels.Where(x => x.LabelId == labelData.LabelId).FirstOrDefault();
                if(validlabel == null)
                {
                    this.userContext.Add(labelData);
                    await this.userContext.SaveChangesAsync();
                    return "Label added to note";
                }
                return "label id error";
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<string> AddLabelToUserAcc(LabelModel labelData)
        {
            try
            {
                var validlabel = this.userContext.Labels.Where(x => x.LabelId == labelData.LabelId).FirstOrDefault();
                if (validlabel == null)
                {
                    this.userContext.Add(labelData);
                    await this.userContext.SaveChangesAsync();
                    return "Label added to account";
                }
                return "label id error";
            }
            catch(ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
        public async Task<string> DeleteLabelFromAllNotes(int userId, string labelText)
        {
            try
            {
                if (!labelText.Equals(""))
                {
                    //var label = this.userContext.LabelsTB.Where(x => x.LabelText == labelText).FirstOrDefault();
                    IEnumerable<LabelModel> label = from x in this.userContext.Labels where x.Label == labelText select x;
                    IEnumerable<LabelModel> userLabel = from x in label where x.UserId == userId select x;
                    foreach (var x in userLabel)
                    {
                        this.userContext.Remove(x);
                    }
                    await this.userContext.SaveChangesAsync();
                    return "Label removed from all notes";
                }
                return "Label text is empty";
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<string> RemoveLabelFromNote(int userId, int noteId)
        {
            try
            {
                if (noteId != 0)
                {
                    var label = this.userContext.Labels.Where(x => x.NoteId == noteId).FirstOrDefault();
                    this.userContext.Remove(label);
                    await this.userContext.SaveChangesAsync();
                    return "Label removed from one notes";
                }
                return "Note id is zero";
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public IEnumerable<LabelModel> GetAllLabelForUser(int userId)
        {
            try
            {
                
                IEnumerable<LabelModel> result = from x in this.userContext.Labels where x.UserId == userId select x;
                return result;
            }
            catch(ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public IEnumerable<LabelModel> GetNotesbylabel(int userId, string labeltext)
        {
            try
            {
                IEnumerable<LabelModel> tempresult;
                var temp = from x in this.userContext.Labels where x.UserId == userId select x;
                tempresult = temp.Where(x => x.Label == labeltext); 
                return tempresult;
            }
            catch(ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<string> UpdateLabel(int userId, string lblName, string editlblName)
        {
            try
            {
                var lblNameList = this.userContext.Labels.Where(x => x.UserId == userId && x.Label.Equals(lblName)).ToList<LabelModel>();
                lblNameList.ForEach(a => a.Label = editlblName);
                await this.userContext.SaveChangesAsync();
                return "Update Successful";
            }
            catch(ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
