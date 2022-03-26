using Entities;
using MedTechProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;
        private readonly AboutServices _aboutServices;
        private readonly QualityServices _qualityServices;
        private readonly DoctorServices _doctorServices;
        private readonly HospitalServices _hospitalServices;
        private readonly NewServices _newServices;
        private readonly CraftServices _craftServices;
        private readonly SubscribeServices _subscribeServices;
        private readonly BookServices _bookServices;

        public AboutController(ILogger<AboutController> logger, AboutServices aboutServices, QualityServices qualityServices, DoctorServices doctorServices, HospitalServices hospitalServices, NewServices newServices, CraftServices craftServices, SubscribeServices subscribeServices, BookServices bookServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
            _qualityServices = qualityServices;
            _doctorServices = doctorServices;
            _hospitalServices = hospitalServices;
            _newServices = newServices;
            _craftServices = craftServices;
            _subscribeServices = subscribeServices;
            _bookServices = bookServices;
        }


        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                About = _aboutServices.GetAboutById(12),
                Quality = _qualityServices.GetQualityById(3),
                Doctor = _doctorServices.GetDoctorAll(),
                Hospital = _hospitalServices.GetAll(),
                New = _newServices.GetAll(),
                Craft = _craftServices.GetAll()

            };
            return View(homeVM);
        }

        [HttpPost]
        public IActionResult Index(Book book, Subscribe subscribe)
        {
            if (book.Name == null & book.Message == null & book.Date == null)
            {
                _subscribeServices.Post(subscribe);
            }
            else
            {
                _bookServices.Postt(book);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
