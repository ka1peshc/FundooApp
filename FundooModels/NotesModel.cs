using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FundooModels
{
    public class NotesModel
    {
        [Key]
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        [DefaultValue(false)]
        public bool IsPin { get; set; }
        [DefaultValue(false)]
        public string RemindMe { get; set; }
        [DefaultValue("white")]
        public string Color { get; set; }
        public string AddImage { get; set; }
        [DefaultValue(false)]
        public bool IsArchive { get; set; }
        [DefaultValue(false)]
        public bool IsTrash { get; set; }

        [ForeignKey("RegisterModel")]
        public int UserID { get; set; }
        public virtual RegisterModel RegisterModel { get; set; }
    }
}
