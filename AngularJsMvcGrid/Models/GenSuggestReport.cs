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
    
    public partial class GenSuggestReport
    {
        public System.Guid ID { get; set; }
        public Nullable<System.Guid> ParentID { get; set; }
        public System.Guid CreatedBy { get; set; }
        public int SlNo { get; set; }
        public string Notes { get; set; }
        public string Description { get; set; }
        public int RecordType { get; set; }
        public int RecordStatus { get; set; }
        public Nullable<System.Guid> ReviewedBy { get; set; }
        public string SectionName { get; set; }
        public Nullable<System.DateTime> WIPDate { get; set; }
        public Nullable<System.DateTime> PausedDate { get; set; }
        public Nullable<System.DateTime> ClosedDate { get; set; }
        public Nullable<System.DateTime> NotAnIssueDate { get; set; }
        public int DataRowVersion { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public Nullable<System.Guid> UserID { get; set; }
        public Nullable<long> ChangeSetNumber { get; set; }
        public int IsActive { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<System.Guid> SectionGroupID { get; set; }
        public Nullable<System.Guid> SectionID { get; set; }
        public long CID { get; set; }
        public Nullable<System.Guid> ClosedByID { get; set; }
    }
}
