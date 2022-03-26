using Entities;
using MedTechProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Controllers
{
    public class TeamDetailController : Controller
    {
        private readonly ILogger<TeamDetailController> _logger;
        private readonly AboutServices _aboutServices;
        private readonly CraftServices _craftServices;
        private readonly DentalServices _dentalServices;
        private readonly ProfessionalServices _professionalServices;
        private readonly SubscribeServices _subscribeServices;

        public TeamDetailController(ILogger<TeamDetailController> logger, AboutServices aboutServices, CraftServices craftServices, DentalServices dentalServices, ProfessionalServices professionalServices, SubscribeServices subscribeServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
            _craftServices = craftServices;
            _dentalServices = dentalServices;
            _professionalServices = professionalServices;
            _subscribeServices = subscribeServices;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                About = _aboutServices.GetAboutById(17),
                Craft = _craftServices.GetAll(),
                Dental = _dentalServices.GetAll(),
                Professional = _professionalServices.GetAll()
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
