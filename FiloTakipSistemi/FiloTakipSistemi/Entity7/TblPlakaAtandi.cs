//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class TblPlakaAtandi
    {
        public int ID { get; set; }
        public string PlakaDurumu { get; set; }
        public Nullable<System.DateTime> SeferTarihi { get; set; }
        public string Plaka { get; set; }
        public string SurucuAdSoyad { get; set; }
        public string SurucuTelefon { get; set; }
        public string SurucuTC { get; set; }
        public string MusteriAdi { get; set; }
        public string YuklemeNoktasi { get; set; }
        public string YuklemeIl { get; set; }
        public string YuklemeIlcesi { get; set; }
        public string Tonaj { get; set; }
        public string TeslimNoktasi { get; set; }
        public string TeslimIli { get; set; }
        public string TeslimIlcesi { get; set; }
        public string NavlunTutar { get; set; }
        public string Aciklama { get; set; }
        public string SonNokta { get; set; }
        public Nullable<System.DateTime> TahminiVaris { get; set; }
        public Nullable<System.DateTime> Gerceklesen { get; set; }
        public Nullable<System.DateTime> YuklemeNoktasiVarısTarihi { get; set; }
        public Nullable<System.DateTime> YuklemeNoktasiCikisTarihi { get; set; }
        public Nullable<System.DateTime> TeslimNoktasiCikisTarihi { get; set; }
        public string TMSOrderID { get; set; }
        public string PozisyonNo { get; set; }
    }
}
