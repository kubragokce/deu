using deu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net.Mail;
using System.Net;

namespace deu.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private TalepContext context = new TalepContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TalepEkle()
        {
            ViewBag.YazilimId = new SelectList(context.Yazilim, "ID", "YazilimAdi");
            ViewBag.SatanFirmaId = new SelectList(context.SatanFirma, "ID", "FirmaAdi");
            ViewBag.TalepEdenKurumId = new SelectList(context.TalepEdenKurum, "ID", "KurumAdi");

            return View();
        }
       
        public ActionResult TalepListele()
        {
            ViewBag.YazilimId = new SelectList(context.Yazilim, "ID", "YazilimAdi");
            ViewBag.SatanFirmaId = new SelectList(context.SatanFirma, "ID", "FirmaAdi");
            ViewBag.TalepEdenKurumId = new SelectList(context.TalepEdenKurum, "ID", "KurumAdi");
            var talepler = context.Talep.Include(y => y.Yazilim).Include(s => s.SatanFirma).Include(t => t.TalepEdenKurum).ToList();
            //var talepler = context.Talep.ToList();s
            return View(talepler);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TalepEkle([Bind(Include = "ID,YazilimId,SatanFirmaId,TalepEdenKurumId,AlimUcreti,AlimTarihi,BitisTarihi")] Taleps talep)
        {
            if (ModelState.IsValid)
            {
                context.Talep.Add(talep);
                context.SaveChanges();
                return RedirectToAction("TalepListele");
            }
            ViewBag.YazilimId = new SelectList(context.Yazilim, "ID", "YazilimAdi");
            ViewBag.SatanFirmaId = new SelectList(context.SatanFirma, "ID", "FirmaAdi");
            ViewBag.TalepEdenKurumId = new SelectList(context.TalepEdenKurum, "ID", "KurumAdi");

            return View(talep);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TalepListele([Bind(Include = "ID,YazilimId,SatanFirmaId,TalepEdenKurumId,AlimUcreti,AlimTarihi,BitisTarihi")] Taleps talep)
            {
        
            try
            { 
                if (ModelState.IsValid)
                {
                   
                    var talepEdenKurumlar = context.TalepEdenKurum.ToList();
                    var yazilimlar = context.Yazilim.ToList();
                    var satanFirmalar = context.SatanFirma.ToList();
                    TalepEdenKurums gonderilecekKurum = (TalepEdenKurums)talepEdenKurumlar.Where(i => i.ID == talep.TalepEdenKurumId).Select(i => i).FirstOrDefault();
                    SatanFirmas satanFirma = (SatanFirmas)satanFirmalar.Where(i => i.ID == talep.SatanFirmaId).Select(i => i).FirstOrDefault();
                    Yazilims yazilim = (Yazilims)yazilimlar.Where(i => i.ID == talep.YazilimId).Select(i => i).FirstOrDefault();
                    SmtpClient client = new SmtpClient();
                    MailAddress from = new MailAddress(gonderilecekKurum.Email);
                    MailAddress to = new MailAddress("e47822724@gmail.com");//bizim mail adresi
                    MailMessage msg = new MailMessage(from, to);
                    msg.IsBodyHtml = true;
                    msg.Subject = "Anlaşmanızın Bitiş Tarihi Yaklaşıyor!";
                    msg.Body += yazilim.YazilimAdi + " yazılımı için " + satanFirma.FirmaAdi + " firmasıyla yaptığınız anlaşmanın sona ermesine "+ ((int)talep.BitisTarihi.Subtract(DateTime.Now).TotalDays) + " gün kalmıştır. Bitiş Tarihi: " + talep.BitisTarihi;
                    msg.CC.Add(gonderilecekKurum.Email);//herkes görür
                    NetworkCredential info = new NetworkCredential("e47822724@gmail.com", "denememaili");
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Credentials = info;
                    client.Send(msg);
                    var t = context.Talep.Where(i => i.ID == talep.ID).Select(i=>i).FirstOrDefault();
                    t.MailGonderildiMi = true;
                    context.SaveChanges();
                    ViewBag.Success = "Mailiniz başarılı bir şekilde gönderildi."; //Bu kısımlarda ise kullanıcıya bilgi vermek amacı ile olur
                    return RedirectToAction("TalepListele");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Mail gönderilirken bir hata oluştu."; //Bu kısımlarda ise kullanıcıya bilgi vermek amacı ile olur
            }
            var talepler = context.Talep.Include(y => y.Yazilim).Include(s => s.SatanFirma).Include(t => t.TalepEdenKurum).ToList();
            ViewBag.YazilimId = new SelectList(context.Yazilim, "ID", "YazilimAdi");
            ViewBag.SatanFirmaId = new SelectList(context.SatanFirma, "ID", "FirmaAdi");
            ViewBag.TalepEdenKurumId = new SelectList(context.TalepEdenKurum, "ID", "KurumAdi");
           
            return View(talepler);
        }

    }
}