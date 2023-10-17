using Lesson01.Models;
using Lesson01.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson01.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoriesController()
        {
            _categoryService = new CategoryService();
        }

        // GET: CategoriesController
        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories();

            return View(categories);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categoryService.FindById(id);

            if (category is null)
            {
                return View("Category not found");
            }

            return View(category);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category newCategory)
        {
            try
            {
                _categoryService.Create(newCategory);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _categoryService.FindById(id);

            if (category is null)
            {
                return View("Category not found");
            }

            return View(category);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category categoryToUpdate)
        {
            try
            {
                _categoryService.Update(categoryToUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categoryService.FindById(id);

            if (category is null)
            {
                return View("Category not found");
            }

            return View(category);
        }

        // POST: CategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                _categoryService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
