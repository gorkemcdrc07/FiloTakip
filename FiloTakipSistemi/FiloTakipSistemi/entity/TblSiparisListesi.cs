//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FiloTakipSistemi.entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblSiparisListesi
    {
        public int ID { get; set; }
        public string Plaka { get; set; }
        public string MusteriAdi { get; set; }
        public string HizmetTipi { get; set; }
        public string ProjeAdi { get; set; }
        public string AracTipi { get; set; }
        public Nullable<System.DateTime> SiparisTarihi { get; set; }
        public string SiparisNo { get; set; }
        public Nullable<System.DateTime> YuklemeTarihi { get; set; }
        public string NoktaSayisi { get; set; }
        public string YuklemeNoktasi { get; set; }
        public string YuklemeIl { get; set; }
        public string YuklemeIlce { get; set; }
        public string TeslimNoktasi { get; set; }
        public string TeslimIl { get; set; }
        public string TeslimIlce { get; set; }
        public string PozisyonNo { get; set; }
        public string TahminiKm { get; set; }
        public string TahminiVarisSaatTarih { get; set; }
    }
}
