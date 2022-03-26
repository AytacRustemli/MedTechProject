using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProtectController : Controller
    {
        private readonly ProtectServices _services;
        private readonly IWebHostEnvironment _environment;

        public ProtectController(ProtectServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var protect = _services.GetAll();
            return View(protect);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Protect protect)
        {
            _services.CreateProtect(protect);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var protect = _services.GetProtectById(id.Value);
            return View(protect);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Protect protect, IFormFile Image , string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditProtect(protect, path);

            }
            else
            {
                _services.EditProtect(protect, OldPhoto);
            }


            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var protectdetail = _services.GetProtectDetailById(id.Value);
            return View(protectdetail);
        }

        public async Task<IActionResult> Delete(Protect protect)
        {
            _services.DeleteProtect(protect);
            return RedirectToAction(nameof(Index));
        }
    }
}
