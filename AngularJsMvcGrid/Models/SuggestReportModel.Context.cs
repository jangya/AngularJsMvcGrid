﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IDBOLiveEntities : DbContext
    {
        public IDBOLiveEntities()
            : base("name=IDBOLiveEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GenSuggestReport> GenSuggestReports { get; set; }
        public virtual DbSet<GenSuggestReportComment> GenSuggestReportComments { get; set; }
        public virtual DbSet<GenUserGroup> GenUserGroups { get; set; }
        public virtual DbSet<GenUserSessionDetail> GenUserSessionDetails { get; set; }
    }
}