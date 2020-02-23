using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeatingChart.Models
{
        public class HomeIndexViewModels 
        {
            //Break Model
            public int BreakId { get; set; }
            public int Employee { get; set; }
            public DateTime TimeEntered { get; set; }
            public DateTime? TimeCleared { get; set; }

            //Employee Model
            public int Id { get; set; }
            public string DisplayName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool NotActive { get; set; }
            public int Force { get; set; }
        }
}