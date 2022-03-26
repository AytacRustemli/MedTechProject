using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class QualityController : Controller
    {
        private readonly QualityServices _services;
        private readonly IWebHostEnvironment _environment;

        public QualityController(QualityServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var quality = _services.GetAll();
            return View(quality);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Quality quality)
        {
            _services.CreateQuality(quality);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var quality = _services.GetQualityById(id.Value);
            return View(quality);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Quality quality,IFormFile Image,string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditQuality(quality, path);

            }
            else
            {
                _services.EditQuality(quality, OldPhoto);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var qualitydetail = _services.GetQualityById(id.Value);
            return View(qualitydetail);
        }

        public async Task<IActionResult> Delete(Quality quality)
        {
            _services.DeleteQuality(quality);
            return RedirectToAction(nameof(Index));
        }
    }
}
