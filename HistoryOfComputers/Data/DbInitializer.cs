using HistoryOfComputers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoryOfComputers.Data
{
    public class DbInitializer
    {
        public static void Initialize(HistoryContext context)
        {
            ////=============== Article ================//
            if (context.Articles.Any())
            {
                return;
            }

            var articles = new Article[]
            {
                new Article{PeriodID=1,
                            Title ="The Analytical Engine",
                            Year =1822,
                            Body="<p>English mathematician Charles Babbage conceives of a steam-driven calculating machine that would be able to compute tables of numbers.\", The project, funded by the English government, is a failure. " +
                                     "More than a century later, however, the world’s first computer was actually built. </p>", Reference="Wikipedia", Image="/1.jpg"}
            };

            foreach(Article a in articles)
            {
                context.Articles.Add(a);
            }
            context.SaveChanges();

            //============== Time Periods ==============//
            if (context.TimePeriods.Any())
            {
                return;
            }

            var timePeriods = new TimePeriod[]
            {
                new TimePeriod{PeriodName="Pre-1970s"},
                new TimePeriod{PeriodName="1970s"},                    
                new TimePeriod{PeriodName="1980s"},
                new TimePeriod{PeriodName="1990s"},
                new TimePeriod{PeriodName="2000s"}
            };

            foreach(TimePeriod t in timePeriods)
            {
                context.TimePeriods.Add(t);
            }
            context.SaveChanges();

        }

    }
}
