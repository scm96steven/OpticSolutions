using OpticSolutions.Repositories.Entitys;
using OpticSolutions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class BillingController : Controller
    {


        BillingService repo;

        public BillingController()
        {
            repo = new BillingService();
        }



        public ActionResult OrderDetails()
        {
            return View();
        }

        public ActionResult CreateOrder()
        {
            return View();
        }


        public ActionResult OrderList()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CompleteOrder(Orders ord)
        {

            ord.CreatedDate = DateTime.Now;
            ord.CreatedBy = User.Identity.Name;
      

            repo.CreateOrder(ord);

            return View();
        }


    }
}
