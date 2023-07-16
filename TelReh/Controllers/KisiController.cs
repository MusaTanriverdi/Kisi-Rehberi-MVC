using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Net.Mail;
using TelReh.Models.Context;
using TelReh.Models.Entities;
using TelReh.Models.KisiModel;

namespace TelReh.Controllers
{
    public class KisiController : Controller
    {
        MvcRehberContext db = new MvcRehberContext();
        public IActionResult Index()
        {
            var model = new KisiIndexViewModel
            {
                Kisiler = db.Kisiler.ToList(),
                Sehirler = db.Sehirler.ToList()
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            var model = new KisiEkleViewModel
            {
                Kisi = new Kisi(),
                Sehirler = db.Sehirler.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Ekle(Kisi kisi)
        {
            try
            {
                db.Kisiler.Add(kisi);
                db.SaveChanges();

                TempData["BasariliMesaj"] = "Ekleme İşlemi Başarıyla Gerçekleşti.";
            }
            catch (Exception)
            {

                TempData["HataliMesaj"] = "Hata Oluştu! Lütfen Tekrar Deneyiniz.";   
            }

            

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Guncelle(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Güncellenmek İstenen Kayıt Bulunamadı.";
                return RedirectToAction("Index");
            }

            var model = new KisiGuncelleViewModel
            {
                Kisi = kisi,
                Sehirler = db.Sehirler.ToList()
            };

            ViewBag.Sehirler = new SelectList(db.Sehirler.ToList(), "Id", "SehirAdi");


            return View(model);
        }

        [HttpPost]
        public IActionResult Guncelle(Kisi kisi)
        {
            var eskiKisi = db.Kisiler.Find(kisi.Id);

            if (eskiKisi == null)
            {
                TempData["HataliMesaj"] = "Güncellenmek İstenen Kayıt Bulunamadı.";
                return RedirectToAction("Index");
            }

            eskiKisi.Ad = kisi.Ad;
            eskiKisi.Soyad = kisi.Soyad;
            eskiKisi.EvTelefon = kisi.EvTelefon;
            eskiKisi.CepTelefon = kisi.CepTelefon;
            eskiKisi.IsTelefon = kisi.IsTelefon;
            eskiKisi.EmailAdres = kisi.EmailAdres;
            eskiKisi.Adres = kisi.Adres;
            eskiKisi.SehirId = kisi.SehirId;

            db.SaveChanges();

            TempData["BasariliMesaj"] = "Kisi Bilgileri Başarıyla Güncellendi";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detay(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı.";
                return RedirectToAction("Index");
            }

            var model = new KisiDetayViewModel
            {
                Kisi = kisi,
                Sehirler = db.Sehirler.ToList()
            };
            return View(model);
        }

       
        public IActionResult Sil(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı.";
                return RedirectToAction("Index");
            }

            db.Kisiler.Remove(kisi);
            db.SaveChanges();

            TempData["BasariliMesaj"] = "Kayıt Başarıyla Silindi!";

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult MailGonder(int id)
        {
            var kisi = db.Kisiler.Find(id);

            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kişi Bulunamadı!";
                return RedirectToAction("Index");
            }
            return View(kisi);
        }

        [HttpPost]
        public IActionResult MailGonder(string MailAdres, string Baslik, string Mesaj)
        {
            try
            {
                var gondericimail = new MailAddress("musatanriiverdii@yandex.com");
                var sifre = "udmtdinxqwqomtzs";
                var aliciMail = new MailAddress(MailAdres);
                
                var smtp = new SmtpClient
                {
                    Host = "smtp.yandex.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(gondericimail.Address, sifre)
                };
                
                using (var msg = new MailMessage(gondericimail, aliciMail)
                {
                    IsBodyHtml = true,
                    Subject = Baslik,
                    Body = Mesaj
                })
                {
                    smtp.Send(msg);
                }

                TempData["BasariliMesaj"] = "Mail Gönderme İşlemi Başarıyla Gerçekleşti";
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                TempData["HataliMesaj"] = "Mail Gönderme İşlemi Sırasında Hata Oluştu";
                return RedirectToAction("Index");
            }
        }
    }
}
