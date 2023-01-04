using Business.Abstract;
using Business.Concrete;
using Bussines.Abstract;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class IsGecmisiController : Controller
    {
        private readonly IDahaOnceCalistigiYerlerService service;

        public IsGecmisiController(IDahaOnceCalistigiYerlerService service)
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
        public IActionResult Insert(DahaOnceCalistigiYerler dahaOnceCalistigiYerler , IFormFile file)
        {

            dahaOnceCalistigiYerler.UsersId = 1;

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
                    dahaOnceCalistigiYerler.IsYeriLogo = RastgeleAd;
                    ViewBag.Message = service.Insert(dahaOnceCalistigiYerler);
                }
                else
                {
                    ViewBag.Error = "Lütfen Dosya Uzantısı (.jpg , .jpeg , veya .png olan bir resim yükleyiniz";
                }



            }
            else
            {
                dahaOnceCalistigiYerler.IsYeriLogo = "Default.jpg";
            }
            return Redirect("/admin/KisiselBilgi/Index");
            
        }
        [HttpGet]
        [Route("/admin/IsGecmisi/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(x => x.Id == Id));
           
        }
        [HttpPost]
        [Route("/admin/IsGecmisi/Update/{Id}")]
        public IActionResult Update(int Id , DahaOnceCalistigiYerler dahaOnceCalistigiYerler,IFormFile file)
        {
            dahaOnceCalistigiYerler.UsersId = 1;
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
                    dahaOnceCalistigiYerler.IsYeriLogo = RastgeleAd;
                    ViewBag.Message = service.Update(dahaOnceCalistigiYerler);
                }
                else
                {
                    ViewBag.Error = ("Lütfen jpg , jpeg veya png uazntılı dosya seçiniz");
                }

            }
            else
            {
                
                ViewBag.Mesage = service.Update(dahaOnceCalistigiYerler);
            }

            return View(service.GetById(x => x.Id == Id));
        }
        [Route("/admin/IsGecmisi/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            ViewBag.Message = service.Delete(x => x.Id == Id);
            return Redirect("/admin/KisiselBilgi");
           
        }
    }
}
