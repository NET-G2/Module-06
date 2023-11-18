using DiyorMarket.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DiyorMarket.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICommonRepository _commonRepository;

        public ProductsController(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;

        }

        public IActionResult Index()
        {
            var products = _commonRepository.Products.FindAll().ToList();
            var categories = _commonRepository.Categories.FindAll();
            
            ViewBag.Categories = categories.Select(category =>
            new SelectListItem
            {
                Text = category.Name,
                Value = category.Id.ToString()
            }).ToList();
            ViewBag.Products = products;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
