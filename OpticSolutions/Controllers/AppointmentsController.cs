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
    public class AppointmentsController : Controller
    {


        AppointmentService repo;


        public AppointmentsController()
        {
            repo = new AppointmentService();
        }


        // GET: Appointments
        public ActionResult Index()
        {
            return View();
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Appointments/Create
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

        // GET: Appointments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Appointments/Edit/5
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

        // GET: Appointments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Appointments/Delete/5
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




        public ActionResult CrearCita()
        {
            Appointment ap = new Appointment();
            return View(ap);
        }


        [HttpPost]
        public ActionResult CrearCita(Appointment ap)
        {
            string start = ap.StartDateStr + " " + ap.StartHourStr;
            ap.StartDate = DateTime.Parse(start);

            ap.NumberOfAppointments = repo.CheckAppointments(ap);
            if (!ModelState.IsValid || ap.NumberOfAppointments>0)
            {

                return View(ap);
            }

            else
            {

                return RedirectToAction("Confirm", ap);
            }
          
        }

    
        public ActionResult Confirm(Appointment ap)
        {
         
          
            ap.Date = DateTime.Now;

            string start = ap.StartDateStr + " " + ap.StartHourStr;
            ap.StartDate = DateTime.Parse(start);
            var userRepo = new UserService();
            var user = userRepo.GetUserInfoById(ap.DoctorUsername);
            ap.DoctorFullname = user.FullName();



            return View(ap);
        }

        [HttpPost]
        public ActionResult CreateAppointment(Appointment ap)
        {

            //ap.StartDate = DateTime.Parse(ap.StartDateStr);
            repo.CreateAppointment(ap);

            return RedirectToAction("Index", "Home",null);
        }

        public ActionResult PendingAppointment(Appointment ap)
        {
            AppointmentService asv = new AppointmentService();
            ap.Date = new DateTime(2001, 1, 1);
            var data = asv.GetAllAppointments(ap);
            return View(data);
        }
        
      
        public JsonResult GetAppointments(Appointment ap)
        {
            var list = repo.GetAppointments(ap);

            return Json(list, JsonRequestBehavior.AllowGet);
        }



    }
}
