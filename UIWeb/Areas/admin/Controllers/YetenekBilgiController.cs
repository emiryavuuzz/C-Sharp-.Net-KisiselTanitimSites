using Bussines.Abstract;
using DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class YetenekBilgiController : Controller
    {
        private readonly IYeteneklerService service;
        public YetenekBilgiController(IYeteneklerService service)
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
        public IActionResult Insert(Yetenekler yetenekler)
        {
            yetenekler.UsersId = 1;
            ViewBag.Message = service.Insert(yetenekler);
            return View();
        }
        [HttpGet]
        [Route("/admin/YetenekBilgi/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpPost]
        [Route("/admin/YetenekBilgi/Update/{Id}")]
        public IActionResult Update(Yetenekler yetenekler, int Id)
        {
            ViewBag.MessageId = service.Update(yetenekler);
            return View(service.GetById(x => x.Id == Id));

        }
        [Route("/admin/YetenekBilgi/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            ViewBag.MessageId = service.Delete(x => x.Id == Id);
            return Redirect("/admin/KisiselBilgi");
        }
    }
}
