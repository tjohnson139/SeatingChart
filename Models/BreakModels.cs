using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeatingChart.Models
{
    public class BreakModels
    {
        [Key]
        [Display(Name = "Break Database ID")]
        public int BreakId { get; set; }

        [Required]
        [ForeignKey("EmployeeModels")]
        [Display(Name = "Display Name")]
        public int Employee { get; set; }

        [Required]
        [Display(Name = "Time on the List")]
        [DataType(DataType.DateTime)]
        public DateTime TimeEntered { get; set; }

        [Display(Name = "Time cleared from the list")]
        [DataType(DataType.DateTime)]
        public DateTime? TimeCleared { get; set; }

        // Link to the EmployeeModels Model
        public virtual EmployeeModels EmployeeModels { get; set; }
    }
}