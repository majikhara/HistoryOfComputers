using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryOfComputers.Models
{
    public class Comment
    {
        public int UserID { get; set; }
        public int ArticleID { get; set; }
        public string CommentText { get; set; }
    }
}
