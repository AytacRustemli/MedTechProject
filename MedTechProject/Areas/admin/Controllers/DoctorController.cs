using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class DoctorController : Controller
    {
        private readonly DoctorServices _services;
        private readonly IWebHostEnvironment _environment;
        public DoctorController(DoctorServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var doctor = _services.GetAll();
            return View(doctor);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            _services.CreateDoctor(doctor);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var doctor = _services.GetDoctorById(id.Value);
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditDoctor(doctor, path);

            }
            else
            {
                _services.EditDoctor(doctor, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var doctordetail = _services.GetDoctorDetailById(id.Value);
            return View(doctordetail);
        }

        public async Task<IActionResult> Delete(Doctor doctor)
        {
            _services.DeleteDoctor(doctor);
            return RedirectToAction(nameof(Index));
        }
    }
}
