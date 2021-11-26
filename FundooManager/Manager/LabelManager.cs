using FundooModels;
using FundooRepository.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooManager.Manager
{
    public class LabelManager : ILabelManager
    {
        private readonly ILabelRepository LabelRepository;

        public LabelManager(ILabelRepository repository)
        {
            this.LabelRepository = repository;
        }

        public async Task<string> AddLabelToNote(LabelModel labelData)
        {
            try
            {
                return await this.LabelRepository.AddLabelToNote(labelData);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<string> AddLabelToAccount(LabelModel labelData)
        {
            try
            {
                return await this.LabelRepository.AddLabelToAccount(labelData);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
