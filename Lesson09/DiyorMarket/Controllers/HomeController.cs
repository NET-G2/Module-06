using DiyorMarket.Domain.Interfaces.Repositories;
using DiyorMarket.Infrastructure.Persistence;
using DiyorMarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DiyorMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICustomerRepository repo)
        {
            _logger = logger;
            var r = repo.FindAll().Count();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}