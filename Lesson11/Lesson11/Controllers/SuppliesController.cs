using Lesson11.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lesson11.Controllers
{
    public class SuppliesController : Controller
    {
        private readonly DiyorMarketDbContext _context;
        public SuppliesController(DiyorMarketDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var supplies=_context.Supplies.ToList();
            ViewBag.Supplies = supplies;    
            return View();
        }
    }
}
