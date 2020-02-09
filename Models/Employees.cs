using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeatingChart.Models
{
    public class Employees
    {
        public class EmployeeModels
        {
            [Required]
            [Display(Name = "Employee Database ID")]
            public int Id { get; set; }

            [Required]
            [StringLength(15, ErrorMessage = "The {0} cannot be more than {1} characters long. Ask them to pick a new name.", MinimumLength = 2)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(20, ErrorMessage = "The {0} cannot be more than {1} characters long. Ask them to pick a new name.", MinimumLength = 2)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [StringLength(15, ErrorMessage = "The {0} cannot be more than {1} characters long.", MinimumLength = 2)]
            [Display(Name = "Display Name")]
            public string DisplayName { get; set; }

            [Display(Name = "Deactivate Employee")]
            public bool IsActive { get; set; }

            [Display(Name = "Forced")]
            public bool Force { get; set; }
        }
    }
}


public class Application : IdentityDbContext<ApplicationUser>
{
    public EmpDBContext()
    : base("DefaultConnection", throwIfV1Schema: false)
    {
    }
    public static EmpDBContext Create()
    {
        return new EmpDBContext();
    }
}