using Lesson11.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lesson11.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly DiyorMarketDbContext _dbContext;
        public SuppliersController(DiyorMarketDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var suppliers= _dbContext.Suppliers.ToList();
            ViewBag.Suppliers = suppliers;
            return View();
        }
    }
}
