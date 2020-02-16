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
        [Required]
        [Display(Name = "Break Database ID")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("EmployeeModels")]
        [Display(Name = "Display Name")]
        public int Employee { get; set; }

        [Required]
        [Display(Name = "Time on the List")]
        public DateTime TimeEntered { get; set; }

        [Required]
        [Display(Name = "Time cleared from the list")]
        public DateTime? TimeCleared { get; set; }

        public virtual EmployeeModels EmployeeModels { get; set; }
    }
}