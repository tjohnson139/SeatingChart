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
    
    public partial class DthModels
    {
        public int DthId { get; set; }
        public int DthEmployee { get; set; }
        public System.DateTime DthTimeEntered { get; set; }
        public Nullable<System.DateTime> DthTimeCleared { get; set; }
    
        public virtual EmployeeModels EmployeeModels { get; set; }
    }
}
