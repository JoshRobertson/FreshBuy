﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment_2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Assignment2Entities : DbContext
    {
        public Assignment2Entities()
            : base("name=Assignment2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BadWord> BadWords { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
