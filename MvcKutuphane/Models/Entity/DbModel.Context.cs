﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBKUTUPHANEEntities : DbContext
    {
        public DBKUTUPHANEEntities()
            : base("name=DBKUTUPHANEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLCEZALAR> TBLCEZALAR { get; set; }
        public virtual DbSet<TBLHAREKET> TBLHAREKET { get; set; }
        public virtual DbSet<TBLKASA> TBLKASA { get; set; }
        public virtual DbSet<TBLKATEGORI> TBLKATEGORI { get; set; }
        public virtual DbSet<TBLKITAP> TBLKITAP { get; set; }
        public virtual DbSet<TBLUYELER> TBLUYELER { get; set; }
        public virtual DbSet<TBLYAZAR> TBLYAZAR { get; set; }
        public virtual DbSet<TBLPERSONEL> TBLPERSONEL { get; set; }
        public virtual DbSet<TBLHAKKIMIZDA> TBLHAKKIMIZDA { get; set; }
        public virtual DbSet<TBLILETISIM> TBLILETISIM { get; set; }
        public virtual DbSet<TBLMESAJLAR> TBLMESAJLAR { get; set; }
        public virtual DbSet<TBLDUYURULAR> TBLDUYURULAR { get; set; }
        public virtual DbSet<TBLADMIN> TBLADMIN { get; set; }
    
        public virtual ObjectResult<string> enFazlaKitapYazar()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enFazlaKitapYazar");
        }
    
        public virtual ObjectResult<string> enCokKitapYayinevi()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enCokKitapYayinevi");
        }
    
        public virtual ObjectResult<string> enAktifUye()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enAktifUye");
        }
    
        public virtual ObjectResult<string> enBasariliPer()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enBasariliPer");
        }
    
        public virtual ObjectResult<string> enOkunanKitap()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enOkunanKitap");
        }
    }
}
