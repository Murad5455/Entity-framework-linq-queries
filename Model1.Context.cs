﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ENTITYORNEK
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DB_SINAVOGRENCIEntities : DbContext
    {
        public DB_SINAVOGRENCIEntities()
            : base("name=DB_SINAVOGRENCIEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBLDERSLER> TBLDERSLERs { get; set; }
        public virtual DbSet<TBLNOTLAR> TBLNOTLARs { get; set; }
        public virtual DbSet<TBLOGRENCI> TBLOGRENCIs { get; set; }
        public virtual DbSet<TBLKULUPLER> TBLKULUPLERs { get; set; }
    
        public virtual ObjectResult<NOTLISTELE_Result> NOTLISTELE()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<NOTLISTELE_Result>("NOTLISTELE");
        }
    }
}