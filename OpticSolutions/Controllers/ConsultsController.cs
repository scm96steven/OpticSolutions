using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class ConsultsController : Controller
    {
        // GET: Consults
        public ActionResult Index()
        {
            return View();
        }

        // GET: Consults/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Consults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consults/Create
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

        // GET: Consults/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Consults/Edit/5
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

        // GET: Consults/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Consults/Delete/5
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
