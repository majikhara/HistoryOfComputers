using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryOfComputers.Models.HistoryViewModels
{
    public class ArticleCommentData
    {
        public IEnumerable<Article> Articles { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
