using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class DentalController : Controller
    {
        private readonly  DentalServices _services;

        private readonly IWebHostEnvironment _environment;

        public DentalController(DentalServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }


        public IActionResult Index()
        {
            var dental = _services.GetAll();
            return View(dental);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dental dental)
        {
            _services.CreateDental(dental);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            var dental = _services.GetDentalById(id.Value);

            return View(dental);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Dental dental, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditDental(dental, path);

            }
            else
            {
                _services.EditDental(dental, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var dentaldetail = _services.GetDentalDetailById(id.Value);
            return View(dentaldetail);
        }

        public async Task<IActionResult> Delete(Dental dental)
        {
            _services.DeleteDental(dental);
            return RedirectToAction(nameof(Index));
        }
    }
}
