﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarcoSRestApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class desk_rnaEntities : DbContext
    {
        public desk_rnaEntities()
            : base("name=desk_rnaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Current_Details> Current_Details { get; set; }
        public virtual DbSet<Currenty> Currenties { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
    }
}
