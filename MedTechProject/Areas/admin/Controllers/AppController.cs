using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class AppController : Controller
    {
        private readonly AppServices _services;
        private readonly IWebHostEnvironment _environment;
        public AppController(AppServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var app = _services.GetAll();
            return View(app);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(App app)
        {
            _services.CreateApp(app);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var app = _services.GetAppById(id.Value);
            return View(app);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(App app,IFormFile Image,string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditApp(app, path);

            }
            else
            {
                _services.EditApp(app, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var appdetail = _services.GetAppDetailById(id.Value);
            return View(appdetail);
        }

        public async Task<IActionResult> Delete(App app)
        {
            _services.DeleteApp(app);
            return RedirectToAction(nameof(Index));
        }
    }
}
