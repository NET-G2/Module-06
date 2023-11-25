using Lesson11.Data;
using Lesson11.Models;
using Lesson11.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson11.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DiyorMarketDbContext _context;
        private readonly CategoriesServies _service;

        public CategoriesController(DiyorMarketDbContext context)
        {
            _context = context;
            _service = new CategoriesServies(context);
        }
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category) 
        {
            _service.CreateCategories(category);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var categories = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                categories = categories.Where(p => p.Name.Contains(searchString));
            }

            ViewBag.Categories = categories.ToList();
            return View();
        }
    }
}
