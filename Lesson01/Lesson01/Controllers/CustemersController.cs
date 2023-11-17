using Lesson01.CustemerServices;
using Lesson01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lesson01.Controllers
{
    public class CustemersController : Controller
    {
        private readonly CustemersServices _custemerServices;

        public CustemersController()
        {
			_custemerServices = new CustemersServices();
        }
        public ActionResult Index()
        {
            var custemer = _custemerServices.GetCustemers();

			return View(custemer);
        }

        // GET: CustemersController/Details/5
        public ActionResult Details(int id)
        {
            var custemer = _custemerServices.FindById(id);

			if (custemer is null)
			{
				return View("Custemer not found");
			}

			return View(custemer);
        }

        // GET: CustemersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustemersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Custemers newCustemer)
        {
            try
            {
                _custemerServices.Create(newCustemer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustemersController/Edit/5
        public ActionResult Edit(int id)
        {
            var custemer = _custemerServices.FindById(id);

			if (custemer is null)
			{
				return View("Custemer not found");
			}

			return View(custemer);
        }

        // POST: CustemersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Custemers custemersServices)
        {
            try
            {
                _custemerServices.Update(custemersServices);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustemersController/Delete/5
        public ActionResult Delete(int id)
        {
            var custemer = _custemerServices.FindById(id);

			if (custemer is null)
			{
				return View("Custemer not found");
			}

			return View(custemer);
        }

        // POST: CustemersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Custemers custemersServices)
        {
            try
            {
                _custemerServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
