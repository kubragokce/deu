using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace deu.Models
{
    public class Yazilims
    {
        [Key]
        public int ID { get; set; }
        public string YazilimAdi { get; set; }
        public string Aciklama { get; set; }

        public List<Taleps> Taleps { get; set; } //emin değilim bire çok ilişki
    }
}