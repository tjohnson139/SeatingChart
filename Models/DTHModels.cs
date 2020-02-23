using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeatingChart.Models
{
    public class DTHModels
    {
        [Key]
        [Required]
        [Display(Name = "DTH Database ID")]
        public int DthId { get; set; }

        [Required]
        [ForeignKey("EmployeeModels")]
        [Display(Name = "Display Name")]
        public int EmployeeDth { get; set; }

        [Required]
        [Display(Name = "Time on the List")]
        public DateTime TimeEnteredDth { get; set; }

        [Required]
        [Display(Name = "Time cleared from the list")]
        public DateTime? TimeClearedDth { get; set; }

        [Required]
        [Display(Name = "Position")]
        public int PositionDth { get; set; }

        public virtual EmployeeModels EmployeeModels { get; set; }
        public virtual PositionModels PositionModels { get; set; }
    }
}