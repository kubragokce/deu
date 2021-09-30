using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace deu.Models
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<TalepContext>
    {
        protected override void Seed(TalepContext context)
        {/*
            List<Yazilim> yazilims = new List<Yazilim>()
            {
                new Yazilim(){ adi= "Yazılım 1", aciklama="Açıklama 1"},
                new Yazilim(){adi ="Yazılım 2", aciklama="Açıklama 2"}
            };
            foreach(var item in yazilims)
            {
                context.yazilims.Add(item);
            }

            List<SatanFirma> satanFirmas = new List<SatanFirma>()
            {
                new SatanFirma(){ adi= "Firma 1"},
                new SatanFirma(){adi ="Firma 2"}
            };
            foreach (var item in satanFirmas)
            {
                context.satanFirmas.Add(item);
            }

            List<TalepEdenKurum> talepEdenKurums = new List<TalepEdenKurum>()
            {
                new TalepEdenKurum(){ adi= "Kurım 1",telefon="12345678910",adres="adres 1"},
                new TalepEdenKurum(){adi ="Kurum 2",telefon="12345678911",adres="adres 2"}
            };
            foreach (var item in talepEdenKurums)
            {
                context.talepEdenKurums.Add(item);
            }*/
            base.Seed(context);
        }
    }
}