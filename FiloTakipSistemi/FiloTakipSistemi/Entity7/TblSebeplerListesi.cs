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
    
    public partial class TblSebeplerListesi
    {
        public int ID { get; set; }
        public string Plaka { get; set; }
        public string SurucuAdı { get; set; }
        public string SurucuTelefon { get; set; }
        public string SurucuTC { get; set; }
        public string SonIl { get; set; }
        public string SonIlce { get; set; }
        public string Sebep { get; set; }
        public Nullable<System.DateTime> BaslangıcTarihi { get; set; }
        public Nullable<System.DateTime> BitisTarihi { get; set; }
        public string Aciklama { get; set; }
    }
}