using Entities;
using MedTechProject.Areas.admin;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class AboutController : Controller
    {
        private readonly AboutServices _services;

        private readonly IWebHostEnvironment _environment;

        public AboutController(AboutServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }


        public IActionResult Index()
        {
            var about = _services.GetAll();
            return View(about);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
            _services.CreateAbout(about);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var about = _services.GetAboutById(id.Value);
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(About about, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditAbout(about, path);

            }
            else
            {
                _services.EditAbout(about, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var aboutdetail = _services.GetAboutDetailById(id.Value);
            return View(aboutdetail);
        }

        public async Task<IActionResult> Delete(About about)
        {
            _services.DeleteAbout(about);
            return RedirectToAction(nameof(Index));
        }
    }
}
