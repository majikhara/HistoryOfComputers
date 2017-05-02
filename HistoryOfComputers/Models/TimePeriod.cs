using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryOfComputers.Models
{
    public class TimePeriod
    {
        public int PeriodID { get; set; } //PK
        public string PeriodName { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}
