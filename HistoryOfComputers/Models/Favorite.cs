using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryOfComputers.Models
{
    public class Favorite
    {
        [Key]
        [StringLength(450)]
        public string FavoriteID { get; set; } //PK

        [Required]
        public string UserID { get; set; }

        public int ArticleID { get; set; } //FK

        public virtual Article Article { get; set; }

    }
}
