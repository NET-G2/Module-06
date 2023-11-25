using Lesson11.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lesson11.Controllers
{
    public class SalesController : Controller
    {
        private readonly DiyorMarketDbContext _context;
        public SalesController(DiyorMarketDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var sales=_context.Sales.ToList();
            ViewBag.Sales = sales;  
            return View();
        }
    }
}
