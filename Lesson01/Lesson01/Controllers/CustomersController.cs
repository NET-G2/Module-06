using Lesson01.Models;
using Lesson01.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson01.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerService _customerService;

        public CustomersController()
        {
            _customerService = new CustomerService();
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            var customer = _customerService.GetCustomers();
            return View(customer);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customerService.FindById(id);

            if (customer is null)
            {
                return View("Customer not found");
            }
            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer newCustomer)
        {
            try
            {
                _customerService.Create(newCustomer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var customer = _customerService.FindById(id);

            if (customer is null)
            {
                return View("Customer not found");
            }

            return View(customer);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customerToUpdate)
        {
            try
            {
                _customerService.Update(customerToUpdate);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerService.FindById(id);
            if (customer is null)
            {
                View("Customer not found");
            }

            return View(customer);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _customerService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
