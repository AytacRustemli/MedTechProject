using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class CraftController : Controller
    {
        private readonly CraftServices _services;
        private readonly IWebHostEnvironment _environment;

        public CraftController(CraftServices services, IWebHostEnvironment environment)
        {
            _services = services;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var news = _services.GetAll();
            return View(news);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Craft craft)
        {
            _services.CreateCraft(craft);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var craft = _services.GetCraftById(id.Value);
            return View(craft);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Craft craft, IFormFile Image, string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditCraft(craft, path);

            }
            else
            {
                _services.EditCraft(craft, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var craftdetail = _services.GetCraftDetailById(id.Value);
            return View(craftdetail);
        }

        public async Task<IActionResult> Delete(Craft craft)
        {
            _services.DeleteCraft(craft);
            return RedirectToAction(nameof(Index));
        }
    }
}
