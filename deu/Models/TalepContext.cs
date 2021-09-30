using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace deu.Models
{
    public class TalepContext:DbContext
    {
        public TalepContext():base("deuConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<Yazilims> Yazilim { get; set; }
        public DbSet<SatanFirmas> SatanFirma { get; set; }
        public DbSet<TalepEdenKurums> TalepEdenKurum { get; set; }
        public DbSet<Taleps> Talep { get; set; }
    }
}