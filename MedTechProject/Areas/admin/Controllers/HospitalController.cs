using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class HospitalController : Controller
    {
        private readonly HospitalServices _services;
        private readonly IWebHostEnvironment _environment;

        public HospitalController(HospitalServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var hospital = _services.GetAll();
            return View(hospital);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
             _services.CreateHospital(hospital);
             return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var hospital = _services.GetHospitalById(id.Value);
            return View(hospital);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Hospital hospital, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditHospital(hospital, path);

            }
            else
            {
                _services.EditHospital(hospital, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var hospitaldetail = _services.GetHospitalDetailById(id.Value);
            return View(hospitaldetail);
        }

        public async Task<IActionResult> Delete(Hospital hospital)
        {
            _services.DeleteHospital(hospital);
            return RedirectToAction(nameof(Index));
        }
    }
}
