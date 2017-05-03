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
        public string id { get; set; } //PK & FK
        public int ArticleID { get; set; } //PK & FK
    }
}
