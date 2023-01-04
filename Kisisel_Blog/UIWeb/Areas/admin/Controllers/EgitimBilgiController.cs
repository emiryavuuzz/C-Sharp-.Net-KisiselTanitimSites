using Bussines.Abstract;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class EgitimBilgiController : Controller
    {
        private readonly IEgitimService service;

        public EgitimBilgiController(IEgitimService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.GetAll());
        }
        [HttpGet]
        public IActionResult Insert () 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert (Egitim egitim) 
        {
            egitim.UsersId= 1;
            ViewBag.Message = service.Insert(egitim);
            return View();
        }
        [HttpGet]
        [Route("/admin/EgitimBilgi/Update/{Id}")]
        public IActionResult Update (int Id) 
        {
            return View(service.GetById(x=>x.Id==Id));
        }
        [HttpPost]
        [Route("/admin/EgitimBilgi/Update/{Id}")]
        public IActionResult Update (Egitim egitim , int Id) 
        {
            ViewBag.MessageId = service.Update(egitim);
            return View(service.GetById(x => x.Id == Id));
            
        }
        [Route("/admin/EgitimBilgi/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            ViewBag.Message = service.Delete(x => x.Id == Id);
            return Redirect("/admin/KisiselBilgi");
        }
    }
}
