﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuickServiceDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QuickServiceDBContext : DbContext
    {
        public QuickServiceDBContext()
            : base("name=QuickServiceDBContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminDetail> AdminDetails { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }
        public virtual DbSet<CustomerRequest> CustomerRequests { get; set; }
        public virtual DbSet<RequestIdQueue> RequestIdQueues { get; set; }
        public virtual DbSet<StaffDetail> StaffDetails { get; set; }
    }
}