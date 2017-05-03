using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryOfComputers.Models
{
    public class TimePeriod
    {
        [Key]
        public int PeriodID { get; set; } //PK
        public string PeriodName { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
