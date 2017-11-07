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

    }
}