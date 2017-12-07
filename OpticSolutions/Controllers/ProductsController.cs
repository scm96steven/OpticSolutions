using OpticSolutions.Repositories.Entitys;
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
            var data = svc.GetPendingWork(new PendingWork());
            return View(data);
        }

    }
}