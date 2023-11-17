using DiyorMarket.Domain.Interfaces.Repositories;
using DiyorMarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiyorMarket.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICommonRepository _commonRepository;

        public DashboardController(ICommonRepository commonRepository)
        {
            _commonRepository = commonRepository;
            
        }

        public IActionResult Index()
        {
            ViewBag.CustomersCount = _commonRepository.Customers.FindAll().Count();
            ViewBag.SalesCount = _commonRepository.Sales.FindAll().Count();
            ViewBag.ProductsCount = _commonRepository.Products.FindAll().Count();
            ViewBag.SuppliersCount = _commonRepository.Suppliers.FindAll().Count();

            var categories = _commonRepository.Categories
                .FindAll()
                .ToList();
            var productCategories = _commonRepository.ProductCategories
                .FindAll()
                .ToList();
            var saleItems = _commonRepository.SaleItems
                .FindAll()
                .ToList();

            var categorySales = from c in categories
                                join pc in productCategories on c.Id equals pc.CategoryId
                                join si in saleItems on pc.ProductId equals si.ProductId
                                group si by c.Name into groupedCategories
                                select new
                                {
                                    Category = groupedCategories.Key,
                                    SalesCount = groupedCategories.Count()
                                };

            var sales = _commonRepository.Sales.FindAll().ToList()
                .GroupBy(s => s.SaleDate.Month)
                .Select(s => new SplineChartData()
                {
                    Month = DateTime.Parse(s.First().SaleDate.ToString()).ToString("MMM"),
                    SalesCount = s.Count()
                })
                .ToList();
            var supplies = _commonRepository.Supplies.FindAll().ToList()
                .GroupBy(s => s.SupplyDate.Month)
                .Select(s => new SplineChartData()
                {
                    Month = DateTime.Parse(s.First().SupplyDate.ToString()).ToString("MMM"),
                    SuppliesCount = s.Count()
                })
                .ToList();

            var startDate = new DateTime(DateTime.Now.Year, 1, 1);

            string[] summary = Enumerable.Range(0, DateTime.Now.Month)
                .Select(i => startDate.AddMonths(i).ToString("MMM"))
                .ToArray();

            ViewBag.SplineChartData = from month in summary
                                      join sale in sales on month equals sale.Month into saleMonth
                                      from sale in saleMonth.DefaultIfEmpty()
                                      join supply in supplies on month equals supply.Month into supplyMonth
                                      from supply in supplyMonth.DefaultIfEmpty()
                                      select new
                                      {
                                          Month = month,
                                          SalesCount = sale.SalesCount,
                                          SuppliesCount = supply.SuppliesCount
                                      };

            ViewBag.Categories = categorySales;

            return View();
        }
    }
}
