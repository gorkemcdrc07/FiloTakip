﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FiloTakipSistemi.Entity7
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FiloTakipEntities9 : DbContext
    {
        public FiloTakipEntities9()
            : base("name=FiloTakipEntities9")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblAraclar> TblAraclar { get; set; }
        public virtual DbSet<TblAracStatu> TblAracStatu { get; set; }
        public virtual DbSet<TblBolgeler> TblBolgeler { get; set; }
        public virtual DbSet<TblMesafe> TblMesafe { get; set; }
        public virtual DbSet<TblPlakaDurumları> TblPlakaDurumları { get; set; }
        public virtual DbSet<TblSebepler> TblSebepler { get; set; }
        public virtual DbSet<TblSiparisListesi> TblSiparisListesi { get; set; }
        public virtual DbSet<TblRezerve> TblRezerve { get; set; }
        public virtual DbSet<TblTamamlananSeferler> TblTamamlananSeferler { get; set; }
        public virtual DbSet<TblSebeplerListesi> TblSebeplerListesi { get; set; }
        public virtual DbSet<TblPlakaAtandi> TblPlakaAtandi { get; set; }
        public virtual DbSet<TblSiparisListesiYedek> TblSiparisListesiYedek { get; set; }
        public virtual DbSet<TblDetay> TblDetay { get; set; }
        public virtual DbSet<TblGiris> TblGiris { get; set; }
    }
}
