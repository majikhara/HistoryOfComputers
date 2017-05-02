using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryOfComputers.Models
{
    public class Article
    { 
        public int ArticleID { get; set; } //PK
        public int PeriodID { get; set; } //FK
        public string Title { get; set; }
        public string Body { get; set; }
        public string References { get; set; }
        public string Image { get; set; }

        
    }
}
