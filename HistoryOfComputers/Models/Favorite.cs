using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryOfComputers.Models
{
    public class Favorite
    {
        [StringLength(450)]
        public string FavoriteID { get; set; } //PK
        public int ArticleID { get; set; } //FK
        public virtual Article Article { get; set; }

    }
}
