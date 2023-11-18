using Microsoft.AspNetCore.Mvc;

namespace DiyorMarket.Controllers
{
    public class CustomerController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
