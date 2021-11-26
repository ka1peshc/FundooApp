using FundooManager.Manager;
using FundooModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    public class LabelController : ControllerBase
    {
        private readonly ILabelManager labelManager;

        public LabelController(ILabelManager manager)
        {
            this.labelManager = manager;
        }

        [HttpPost]
        [Route("api/createLabelforNote")]
        public async Task<IActionResult> AddLabelToNote(LabelModel labelData)
        {
            try
            {
                string result = await this.labelManager.AddLabelToNote(labelData);
                if (result == "Label added to note")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }

            }
            catch (ArgumentNullException ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("api/createNoteforAccount")]
        public async Task<IActionResult> AddLabelToAccount(LabelModel labelData)
        {
            try
            {
                string result = await this.labelManager.AddLabelToAccount(labelData);
                if (result == "Label added to note")
                {
                    return this.Ok(new ResponseModel<string>() { Status = true, Message = result, Data = " Session data" });
                }
                else
                {
                    return this.BadRequest(new ResponseModel<string>() { Status = false, Message = result });
                }

            }
            catch (ArgumentNullException ex)
            {
                return this.NotFound(new ResponseModel<string>() { Status = false, Message = ex.Message });
            }
        }
    }
}
