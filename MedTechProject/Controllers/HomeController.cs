using System.Diagnostics;
using Entities;
using MedTechProject.Models;
using MedTechProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AboutServices _aboutServices;
        private readonly DoctorServices _doctorServices;
        private readonly QualityServices _qualityServices;
        private readonly ProtectServices _protectServices;
        private readonly HospitalServices _hospitalServices;
        private readonly PatientServices _patientServices;
        private readonly NewServices _newServices;
        private readonly AppServices _appServices;
        private readonly CraftServices _craftServices;
        private readonly SubscribeServices _subscribeServices;
        private readonly BookServices _bookServices;


        public HomeController(ILogger<HomeController> logger, AboutServices aboutServices, DoctorServices doctorServices, QualityServices qualityServices, ProtectServices protectServices, HospitalServices hospitalServices, PatientServices patientServices, NewServices newServices, AppServices appServices, CraftServices craftServices, SubscribeServices subscribeServices, BookServices bookServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
            _doctorServices = doctorServices;
            _qualityServices = qualityServices;
            _protectServices = protectServices;
            _hospitalServices = hospitalServices;
            _patientServices = patientServices;
            _newServices = newServices;
            _appServices = appServices;
            _craftServices = craftServices;
            _subscribeServices = subscribeServices;
            _bookServices = bookServices;
        }


        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                About = _aboutServices.GetAboutById(7),
                Doctor = _doctorServices.GetAll(),
                Quality = _qualityServices.GetQualityById(2),
                Protect = _protectServices.GetAll(),
                Hospital = _hospitalServices.GetAll(),
                Patient = _patientServices.GetAll(),
                New = _newServices.GetAll(),
                App = _appServices.GetAll(),
                Craft = _craftServices.GetAll()
            };
            return View(homeVM);
        }

        [HttpPost]
        public IActionResult Index(Book book, Subscribe subscribe)
        {
            if(book.Name == null & book.Message == null & book.Date == null)
            {
                _subscribeServices.Post(subscribe);
            }
            else
            {
                _bookServices.Postt(book);
            }
            return RedirectToAction(nameof(Index));
        }

       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}