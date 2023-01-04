using Business.Abstract;
using Business.Concrete;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class KisiselBilgiController : Controller
    {
        private readonly IUserService userService;

       public KisiselBilgiController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View(userService.GetAll());
        }
        [HttpGet]
        public IActionResult Insert() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(IFormFile file,Users users)
        {

            users.SonGuncelleme = DateTime.Now;
            if (file!=null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName).ToLower();
                string[] IzinVerilenUzanti = { ".jpg", ".jpeg", ".png" };
                if (IzinVerilenUzanti.Contains(DosyaUzanti))
                {
                    string RastgeleAd = Guid.NewGuid() + DosyaUzanti;
                    string KayitYeri=Path.Combine(Directory.GetCurrentDirectory(),$"wwwroot/images/{RastgeleAd}");

                    using (var Stream = new FileStream(KayitYeri, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    users.ProfilPhoto = RastgeleAd;
                    ViewBag.Message = userService.Insert(users);
                }
                else
                {
                    ViewBag.Error = "Lütfen Dosya Uzantısı (.jpg , .jpeg , veya .png olan bir resim yükleyiniz";
                }


                
            }
            else
            {
                users.ProfilPhoto = "Default.jpg";
            }
            return Redirect("/admin/KisiselBilgi/Index");
        }
        [Route("/admin/KisiselBilgi/Update/{Id}")]
        [HttpGet]
        public IActionResult Update(int Id)
        {
            return View(userService.GetById(x => x.Id == Id));
        }
        [Route("/admin/KisiselBilgi/Update/{Id}")]
        [HttpPost]
        public IActionResult Update(int Id, Users users, IFormFile file)
        {
            users.SonGuncelleme = DateTime.Now;
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
                    users.ProfilPhoto = RastgeleAd;
                    ViewBag.Message = userService.Update(users);
                }
                else
                {
                    ViewBag.Error = ("Lütfen jpg , jpeg veya png uazntılı dosya seçiniz");
                }

            }
            else
            {
              
                ViewBag.Mesage = userService.Update(users);
            }

            return View(userService.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/admin/KisiselBilgi/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            userService.Delete(x => x.Id == Id);
            return Redirect("/admin/KisiselBilgi");

        }
    }
}
