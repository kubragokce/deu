using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace deu.Models
{
    public class SatanFirmas
    {
        [Key]
        public int ID { get; set; }
        public string FirmaAdi { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Email { get; set; }
        public List<Taleps> Taleps { get; set; } //emin değilim bire çok ilişki
    }
}