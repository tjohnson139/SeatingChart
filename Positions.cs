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
    
    public partial class Positions
    {
        public int PositionId { get; set; }
        public string Position { get; set; }
    
        public virtual BreakModel BreakModel { get; set; }
        public virtual DTH DTH { get; set; }
    }
}
