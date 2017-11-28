using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        public ActionResult Index()
        {
            return View();
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
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

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Clients/Edit/5
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

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Clients/Delete/5
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

        public ActionResult Record()
        {
            Client client = new Client();
            client.Names = "Frederick";
            client.Last_Names = "Ramirez Luciano";
            client.Phone = "809-481-6005";
            client.Email = "frederick5@hotmail.com";
            client.IdentificationCard = "402-0042418-8";
           

            return View(client);
        }

        public ActionResult ConsultaCliente()
        {
            return View("ConsultaCliente");
        }

    }
}
