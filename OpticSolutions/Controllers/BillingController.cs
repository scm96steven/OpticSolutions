using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class BillingController : Controller
    {
        // GET: Billing
        public ActionResult Index()
        {
            return View();
        }

        // GET: Billing/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Billing/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Billing/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Billing/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Billing/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Billing/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Billing/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
