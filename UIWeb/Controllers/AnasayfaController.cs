using Business.Abstract;
using Bussines.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Controllers
{
    public class AnasayfaController : Controller
    {
        private readonly IUserService userService;
        private readonly IYeteneklerService yeteneklerService;
        private readonly IEgitimService egitimService;
        private readonly IProjelerService projelerService;
        private readonly ISertifikalarService sertifikalarService;
        private readonly IServislerService servislerService;
        private readonly IDahaOnceCalistigiYerlerService dahaOnceCalistigiYerlerService;
        public AnasayfaController(IUserService userService,IYeteneklerService yeteneklerService, IEgitimService egitimService, IProjelerService projelerService, ISertifikalarService sertifikalarService, IServislerService servislerService, IDahaOnceCalistigiYerlerService dahaOnceCalistigiYerlerService)
        {
            this.userService = userService;
            this.yeteneklerService = yeteneklerService;
            this.egitimService = egitimService;
            this.projelerService = projelerService;
            this.sertifikalarService = sertifikalarService;
            this.servislerService = servislerService;
            this.dahaOnceCalistigiYerlerService = dahaOnceCalistigiYerlerService;
        }
        [Route("/")]
        public IActionResult Index()
        {

            View(servislerService.GetAll());
            View(sertifikalarService.GetAll());
            View(dahaOnceCalistigiYerlerService.GetAll());
            View(projelerService.GetAll());
            View(yeteneklerService.GetAll());
            View(egitimService.GetAll());
            return View(userService.GetById(x=>x.Id==1));
        }
        [Route("/Anasayfa/Details/{Id}")]
        public IActionResult ProjeDetails(int Id)
        {
            return View(projelerService.GetById(x => x.Id == Id));
        }
    }
}
