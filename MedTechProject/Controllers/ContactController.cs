using Entities;
using MedTechProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly AboutServices _aboutServices;
        private readonly DoctorServices _doctorServices;
        private readonly CraftServices _craftServices;
        private readonly SubscribeServices _subscribeServices;
        private readonly BookServices _bookServices;

        public ContactController(ILogger<ContactController> logger, AboutServices aboutServices, DoctorServices doctorServices, CraftServices craftServices, SubscribeServices subscribeServices, BookServices bookServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
            _doctorServices = doctorServices;
            _craftServices = craftServices;
            _subscribeServices = subscribeServices;
            _bookServices = bookServices;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                About = _aboutServices.GetAboutById(16),
                Doctor = _doctorServices.GetContactDoctorAll(),
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
