using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryOfComputers.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [Required]
        public string UserID { get; set; }
        //[Key]
        public int ArticleID { get; set; }

        public string CommentText { get; set; }

        public virtual Article Article { get; set; }
    }
}
