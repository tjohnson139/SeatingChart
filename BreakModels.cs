//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SeatingChart
{
    using System;
    using System.Collections.Generic;
    
    public partial class BreakModels
    {
        public int BreakId { get; set; }
        public int Employee { get; set; }
        public Nullable<System.DateTime> TimeEntered { get; set; }
        public Nullable<System.DateTime> TimeCleared { get; set; }
        public Nullable<System.DateTime> DthTimeCleared { get; set; }
        public Nullable<System.DateTime> DthTimeEntered { get; set; }
    
        public virtual EmployeeModels EmployeeModels { get; set; }
    }
}
