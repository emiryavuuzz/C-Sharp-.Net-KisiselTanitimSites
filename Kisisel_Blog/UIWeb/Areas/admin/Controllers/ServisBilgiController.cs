using Business.Concrete;
using Bussines.Abstract;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class ServisBilgiController : Controller
    {
        private readonly IServislerService service;

        public ServisBilgiController(IServislerService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.GetAll());
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(IFormFile file, Servisler servisler)
        {
            servisler.UsersId = 1;
            if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName).ToLower();
                string[] IzinVerilenUzanti = { ".jpg", ".jpeg", ".png" };
                if (IzinVerilenUzanti.Contains(DosyaUzanti))
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAd}");

                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    servisler.ServisFoto = RastgeleAd;
                    ViewBag.Message = service.Insert(servisler);
                }
                else
                {
                    ViewBag.Error = "Lütfen Dosya Uzantısı (.jpg , .jpeg , veya .png olan bir resim yükleyiniz";
                }



            }
            else
            {
                servisler.ServisFoto = "Default.jpg";
            }
            return Redirect("/admin/KisiselBilgi/Index");
        }
        [Route("/admin/ServisBilgi/Update/{Id}")]
        [HttpGet]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(x => x.Id == Id));
        }
        [Route("/admin/ServisBilgi/Update/{Id}")]
        [HttpPost]
        public IActionResult Update(int Id, Servisler servisler, IFormFile file)
        {
            servisler.UsersId = 1;
            if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName);
                string[] IzinVerilenUzantilar = { ".jpg", ".jpeg", ".png" };
                if (IzinVerilenUzantilar.Contains(DosyaUzanti))
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RastgeleAd}");

                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    servisler.ServisFoto = RastgeleAd;
                    ViewBag.Message = service.Update(servisler);
                }
                else
                {
                    ViewBag.Error = ("Lütfen jpg , jpeg veya png uazntılı dosya seçiniz");
                }

            }
            else
            {
                
                ViewBag.Mesage = service.Update(servisler);
            }

            return View(service.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/admin/ServisBilgi/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(x => x.Id == Id);
            return Redirect("/admin/KisiselBilgi");

        }
    }
}
