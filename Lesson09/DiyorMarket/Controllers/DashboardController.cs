using Microsoft.AspNetCore.Mvc;

namespace DiyorMarket.Controllers
{
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }

    public class ComboBoxFor
    {
        public string CategoryValue { get; set; }
        public string[] CategoryData { get; set; }

        public string FitterValue { get; set; }
        public string[] FitterData { get; set; }

        public ComboBoxFor()
        {
            CategoryData = new string[]
            {
                "Все",
                "Игрушки",
                "Сладости",
                "Напитки"
            };
        }
    }
}
