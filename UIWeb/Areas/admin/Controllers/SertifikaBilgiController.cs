using Bussines.Abstract;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class SertifikaBilgiController : Controller
    {
        private readonly ISertifikalarService service;
        public SertifikaBilgiController(ISertifikalarService service)
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
        public IActionResult Insert(Sertifikalar sertifikalar)
        {
            sertifikalar.UsersId = 1;
            ViewBag.Message = service.Insert(sertifikalar);
            return View();
        }
        [HttpGet]
        [Route("/admin/SertifikaBilgi/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/admin/SertifikaBilgi/Update/{Id}")]
        public IActionResult Update(Sertifikalar sertifikalar, int Id)
        {
            ViewBag.MessageId = service.Update(sertifikalar);
            return View(service.GetById(x => x.Id == Id));

        }
        [Route("/admin/SertifikaBilgi/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            ViewBag.Message = service.Delete(x => x.Id == Id);
            return Redirect("/admin/KisiselBilgi");
        }
    }
}
