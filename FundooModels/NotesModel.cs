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
        public string NoteBody { get; set; }
        [DefaultValue(false)]
        public bool PinBody { get; set; }
        [DefaultValue(false)]
        public bool RemindMe { get; set; }
        [DefaultValue("white")]
        public string Color { get; set; }
        public string AddImage { get; set; }
        [DefaultValue(false)]
        public bool IsArchive { get; set; }
        [DefaultValue(false)]
        public bool IsTrash { get; set; }

        [ForeignKey("UserID")]
        public int UserID { get; set; }
    }
}
