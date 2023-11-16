using DiyorMarket.Domain.Entities;
using DiyorMarket.Domain.Interfaces.Repositories;
using DiyorMarket.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DiyorMarket.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DiyorMarketDbContext _context;
        private readonly ICategoryRepository _categoryRepository;

        public DashboardController(ICategoryRepository categoryRepository, DiyorMarketDbContext context)
        {
            _categoryRepository = categoryRepository;
            _context = context;
        }

        public IActionResult Index()
        {
            var productCategories = _context.ProductCategories.ToList();

            var result = from c in _context.Categories
                         join pc in _context.ProductCategories on c.Id equals pc.CategoryId
                         join si in _context.SaleItems on pc.ProductId equals si.ProductId
                         group si by c.Name into groupedCategories
                         select new
                         {
                             CategoryName = groupedCategories.Key,
                             SalesCount = groupedCategories.Count()
                         };

            ViewBag.Categories = result;

            return View();
        }
    }

    public class ComboBoxFor
    {
        public string CategoryValue { get; set; }
        public string[] CategoryData { get; set; }

        public string FitterValue { get; set; }
        public string[] FitterData { get; set; }

        public string DocumentValue { get; set; }
        public string[] DocumentData { get; set; }

        public ComboBoxFor()
        {
            CategoryData = new string[]
            {
                "Все",
                "Законченные",
                "В процессе",
                "Проблемы"
            };
        }
    }
}
