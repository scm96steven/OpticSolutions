using OpticSolutions.Repositories.Entitys;
using OpticSolutions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class ConsultsController : Controller
    {

        ClientService repo;
        public ConsultsController()
        {
            repo = new ClientService();
        }
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
        [HttpGet]
        public ActionResult Create(Client cli)
        {

            return View(cli);
        }

        // POST: Consults/Create
        [HttpPost]
        public ActionResult Create(Consult con)
        {

            con.DoctorUserName = User.Identity.Name;
            con.Date = DateTime.Now;
            try
            {

                if (con.Description.Length>2)
                {

                    repo.CreateRecord(con);

                    return RedirectToAction("ConsultaCliente","Clients");
                }
                else
                {



                    return View(con.Client);
                }
        
        

                // TODO: Add insert logic here

             
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
