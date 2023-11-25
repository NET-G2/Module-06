using Lesson11.Data;
using Lesson11.Models;
using Lesson11.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Lesson11.Controllers
{
    public class CustomersController : Controller
    {
        private readonly DiyorMarketDbContext _context;
        private readonly CustomersServies _services;

        public CustomersController(DiyorMarketDbContext context)
        {
            _context = context;
            _services=new CustomersServies(context);
        }
        public IActionResult Index()
        {
            var customers=_context.Customers.ToList();
            ViewBag.Customers = customers;
            return View();
        }
        [HttpPost]
        public IActionResult Index(string searchString)
        {
            var customers = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(p => p.FirstName.Contains(searchString));
            }

            ViewBag.Customers = customers.ToList();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _services.CreateCustomer(customer);
            return RedirectToAction(nameof(Index));
        }
    }
}
