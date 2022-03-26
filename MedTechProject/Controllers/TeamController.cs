using Entities;
using MedTechProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Controllers
{
    public class TeamController : Controller
    {
        private readonly ILogger<TeamController> _logger;
        private readonly AboutServices _aboutServices;
        private readonly NewServices _newServices;
        private readonly CraftServices _craftServices;
        private readonly SubscribeServices _subscribeServices;
        private readonly BookServices _bookServices;

        public TeamController(ILogger<TeamController> logger, AboutServices aboutServices, NewServices newServices, CraftServices craftServices, SubscribeServices subscribeServices, BookServices bookServices)
        {
            _logger = logger;
            _aboutServices = aboutServices;
            _newServices = newServices;
            _craftServices = craftServices;
            _subscribeServices = subscribeServices;
            _bookServices = bookServices;
        }
        public IActionResult Index()
        {
            HomeVM homeVM = new()
            {
                About = _aboutServices.GetAboutById(14),
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
