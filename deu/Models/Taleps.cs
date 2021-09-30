using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace deu.Models
{
    public class Taleps
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int YazilimId { get; set; }
        public Yazilims Yazilim { get; set; }

        [Required]
        public int SatanFirmaId { get; set; }
        public SatanFirmas SatanFirma { get; set; }

        [Required]
        public int TalepEdenKurumId { get; set; }
        public TalepEdenKurums TalepEdenKurum { get; set; }

        [Required(ErrorMessage = "Lütfen alım ücreti girin.")]
        public decimal AlimUcreti { get; set; }

        [Required(ErrorMessage = "Lütfen alım tarihi girin.")]
        public DateTime AlimTarihi { get; set; }

        [Required(ErrorMessage = "Lütfen bitiş tarihi girin.")]
        public DateTime BitisTarihi { get; set; }
        public bool MailGonderildiMi { get; set; }
    }
}