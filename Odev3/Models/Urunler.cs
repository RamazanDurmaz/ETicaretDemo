//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Odev3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Urunler
    {
        public int ID { get; set; }
        public string UrunAdi { get; set; }
        public string UrunResmi { get; set; }
        public int Fiyati { get; set; }
        public string StokMiktari { get; set; }
        public int AltKategoriID { get; set; }
    
        public virtual AltKategori AltKategori { get; set; }
    }
}