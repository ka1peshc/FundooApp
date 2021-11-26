using FundooModels;
using FundooRepository.Context;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
                this.userContext.Add(labelData);
                await this.userContext.SaveChangesAsync();
                return "Label added to note";
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}
