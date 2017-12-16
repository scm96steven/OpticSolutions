using OpticSolutions.Repositories.Entitys;
using OpticSolutions.Services;
using OpticSolutions.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class ClientsController : Controller
    {

        ClientService repo;


        public ClientsController()
        {
            repo = new ClientService();
        }


        // GET: Clients
        public ActionResult Index()
        {
            ClientService svc = new ClientService();
            var data = svc.SearchClients(new Client());
            return View(data);
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
        public ActionResult Create(Client cli)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    repo.CreateClient(cli);
                    return RedirectToAction("ConsultaCliente");
              
                }
                else
                {


                    return View(cli);
                }

               
            }
            catch(Exception ex)
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

            return View();
        }

        public ActionResult ConsultaCliente()
        {


            return View();
        }


        [HttpPost]
        public ActionResult ConsultaCliente(Client cli)
        {
            ClientService svc = new ClientService();
            var data = svc.SearchClients(cli);

            return View(data);
        }

        [HttpGet]
        public ActionResult Record(Client cli)
        {
           RecordViewModel data = new RecordViewModel();
            data.Records = repo.GetRecord(cli, User.Identity.Name);
            data.Client = repo.GetClientById(cli);

            return View(data);
        }

     

    }
}
