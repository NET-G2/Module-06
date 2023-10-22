using Lesson01.Models;
using Lesson01.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson01.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsService _productService;

        public ProductsController()
        {
            _productService = new ProductsService();
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            var products = _productService.GetProducts();

            return View(products);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var product = _productService.FindById(id);

            if (product is null)
            {
                return View("Product not found");
            }

            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product newProduct)
        {
            try
            {
                _productService.Create(newProduct);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productService.FindById(id);

            if (product is null)
            {
                return View("Product not found");
            }

            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product productToUpdate)
        {
            try
            {
                _productService.Update(productToUpdate);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productService.FindById(id);

            if (product is null)
            {
                return View("Product not found");
            }

            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _productService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

