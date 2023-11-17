using Lesson01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson01.Controllers
{
    public class ProductsController : Controller
    {
        List<Product> products = new List<Product>();

        public ProductsController()
        {   
            PopulateData();
        }

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product is null)
            {
                return View("Not Found");
            }

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product is null)
            {
                return View("Not Found");
            }

            return View(product);
        }

        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);

            if (product is null)
            {
                return View("Not Found");
            }

            return View(product);

        }

        private void PopulateData()
        {
            products.Add(new Product()
            {
                Id = 1,
                Name = "Snikers",
                Description = "Sweet",
                Price = 500
            });

            products.Add(new Product()
            {
                Id = 2,
                Name = "Twix",
                Description = "Sweet",
                Price = 550
            });

            products.Add(new Product()
            {
                Id = 3,
                Name = "Mars",
                Description = "Sweet",
                Price = 510
            });
        }
    }
}
