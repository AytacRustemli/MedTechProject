using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class PatientController : Controller
    {
        private readonly PatientServices _services;
        private readonly IWebHostEnvironment _environment;

        public PatientController(PatientServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }


        public IActionResult Index()
        {
            var patient = _services.GetAll();
            return View(patient);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        { 
            _services.CreatePatient(patient);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var patient = _services.GetPatientById(id.Value);
            return View(patient);
        }

        [HttpPost]
        public  async Task<IActionResult> Edit(Patient patient,IFormFile Image,string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditPatient(patient, path);

            }
            else
            {
                _services.EditPatient(patient, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail (int? id)
        {
            var patientdetail = _services.GetPatientDetailById(id.Value);
            return View(patientdetail);
        }

        public async Task<IActionResult> Delete(Patient patient)
        {
            _services.DeletePatient(patient);
            return RedirectToAction(nameof(Index));
        }
    }
}
