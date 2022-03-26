using Entities;
using MedTechProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ILogger<ServicesController> _logger;
        private readonly AboutServices _aboutServices;
        private readonly DoctorServices _doctorServices;
        private readonly QualityServices _qualityServices;
        private readonly CraftServices _craftServices;
        private readonly SubscribeServices _subscribeServices;

        public ServicesController(ILogger<ServicesController> logger, AboutServices aboutServices, DoctorServices doctorServices, QualityServices qualityServices, CraftServices craftServices, SubscribeServices subscribeServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
            _doctorServices = doctorServices;
            _qualityServices = qualityServices;
            _craftServices = craftServices;
            _subscribeServices = subscribeServices;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                About = _aboutServices.GetAboutById(13),
                Doctor = _doctorServices.GetAll(),
                Quality = _qualityServices.GetQualityById(5),
                Craft = _craftServices.GetAll()
            };
            return View(homeVM);
        }

        [HttpPost]
        public IActionResult Index(Subscribe subscribe)
        {
            _subscribeServices.Post(subscribe);
            return RedirectToAction(nameof(Index));
        }
    }
}
