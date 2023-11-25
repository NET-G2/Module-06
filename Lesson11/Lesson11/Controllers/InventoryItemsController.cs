using Lesson11.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lesson11.Controllers
{
    public class InventoryItemsController : Controller
    {
        private readonly DiyorMarketDbContext _context;
        public InventoryItemsController(DiyorMarketDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var inventoryItems=_context.InventoryItems.ToList();
            ViewBag.InventoryItems = inventoryItems;
            return View();
        }
    }
}
