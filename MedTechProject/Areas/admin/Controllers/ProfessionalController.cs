using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProfessionalController : Controller
    {
        private readonly ProfessionalServices _services;

        public ProfessionalController(ProfessionalServices services)
        {
            _services = services;
        }


        public IActionResult Index()
        {
            var professional = _services.GetAll();
            return View(professional);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Professional professional)
        {
            _services.CreateProfessional(professional);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            var professional = _services.GetProfessionalById(id.Value);

            return View(professional);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Professional professional)
        {
                _services.EditProfessional(professional);

                return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var professionaldetail = _services.GetProfessionalDetailById(id.Value);
            return View(professionaldetail);
        }

        public async Task<IActionResult> Delete(Professional professional)
        {
            _services.DeleteProfessional(professional);
            return RedirectToAction(nameof(Index));
        }
    }
}
