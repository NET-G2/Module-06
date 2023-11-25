using Lesson11.Data;
using Lesson11.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson11.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DiyorMarketDbContext _context;
        private readonly ProductService _productService;
        public ProductsController(DiyorMarketDbContext context)
        {
            _context = context;
            _productService=new ProductService(context);
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            var categories = _context.Categories.ToList();

            ViewBag.Categories = categories.Select(category =>
            new SelectListItem
            {
                Text = category.Name,
                Value = category.Id.ToString()
            }).ToList();
            ViewBag.Products = products;

            return View();
        }
        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var products = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
            }

            ViewBag.Products = products.ToList();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _productService.CreateProduct(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product updatedProduct)
        {
            _productService.UpdateProduct(updatedProduct);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

    }
}