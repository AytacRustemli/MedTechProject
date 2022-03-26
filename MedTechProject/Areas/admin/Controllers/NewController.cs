using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MedTechProject.Areas.admin.Controllers
{
    [Area("admin")]
    public class NewController : Controller
    {
        private readonly NewServices _services;
        private readonly IWebHostEnvironment _environment;

        public NewController(NewServices services, IWebHostEnvironment environment)
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
        public IActionResult Create(New news) 
        {
            _services.CreateNew(news);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var news = _services.GetNewById(id.Value);
            return View(news);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(New news,IFormFile Image,string OldPhoto)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                _services.EditNew(news, path);

            }
            else
            {
                _services.EditNew(news, OldPhoto);
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            var newdetail = _services.GetNewDetailById(id.Value);
            return View(newdetail);
        }

        public async Task<IActionResult> Delete(New news)
        {
            _services.DeleteNew(news);
            return RedirectToAction(nameof(Index));
        }
    }
}
