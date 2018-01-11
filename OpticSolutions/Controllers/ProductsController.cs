﻿using OpticSolutions.Repositories.Entitys;
using OpticSolutions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class ProductsController : Controller
    {
        ProductService repo;

        public ProductsController()
        {
            repo = new ProductService();
        }

        // GET: Products
        public ActionResult Index()
        {
            var data = repo.GetProducts();



            return View(data);
        }

        public ActionResult Create()
        {
            ViewData["ProductTypes"] = repo.GetProductTypeList();

            return View();
        }
        [HttpPost]
        public ActionResult Create(Product prod)
        {
            repo.CreateProduct(prod);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(Product prod)
        {
            repo.DeleteProduct(prod);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Product prod)
        {
            Product data = repo.GetProductById(prod);

            return View(data);
        }


        [HttpPost]
        public ActionResult EditProduct(Product prod)
        {
            repo.EditProduct(prod);

            return RedirectToAction("Index");
        }


        public ActionResult PenWork()
        {
            ProductService svc = new ProductService();
            var data = svc.GetPendingWork();
            return View(data);
        }

        public ActionResult PendingDelivery()
        {
            ProductService svc = new ProductService();
            var data = svc.GetPendingDelivery();

            return View(data);
        }

        [HttpGet]
        public ActionResult CompletePending(PendingWork pw)
        {
            repo.CompletePendingWork(pw);

           return RedirectToAction("PenWork");
        }

        [HttpGet]
        public ActionResult CompleteDelivery(PendingWork pw)
        {
            repo.CompletePendingDelivery(pw);

            return RedirectToAction("PendingDelivery");
        }




        public JsonResult GetProducts()
        {

            var list = repo.GetProducts();
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetProductById(Product prod)
        {

            var data = repo.GetProductById(prod);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}