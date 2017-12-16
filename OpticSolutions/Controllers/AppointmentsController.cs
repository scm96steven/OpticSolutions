﻿using OpticSolutions.Repositories.Entitys;
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
            return View();
        }

        [HttpPost]
        public ActionResult CrearCita(CreateAppointmentViewModel ap)
        {
            CreateAppointmentViewModel newAp = new CreateAppointmentViewModel();
            newAp.ApList = repo.GetAppointments(ap.Appointment);
            ap.Appointment.Date = DateTime.Now;
            ap.Appointment.DoctorId = 1;

            return View(ap);
        }

    }
}
