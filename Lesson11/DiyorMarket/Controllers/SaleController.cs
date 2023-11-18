using Microsoft.AspNetCore.Mvc;

namespace DiyorMarket.Controllers
{
    public class SaleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
