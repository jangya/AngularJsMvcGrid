//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularJsMvcGrid.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GenSuggestReportComment
    {
        public System.Guid ID { get; set; }
        public int SlNo { get; set; }
        public Nullable<System.Guid> SuggestReportID { get; set; }
        public string Comments { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.Guid> UserID { get; set; }
        public Nullable<long> ChangeSetNumber { get; set; }
        public int IsActive { get; set; }
    }
}
