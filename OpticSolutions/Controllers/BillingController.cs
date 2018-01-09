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

            var list = repo.GetOrders();

            return View(list);
        }


        [HttpPost]
        public ActionResult CompleteOrder(Orders ord)
        {

            if (ord.OrderDetails.Count>0)
            {
                ord.CreatedDate = DateTime.Now;
                ord.CreatedBy = User.Identity.Name;
                repo.CreateOrder(ord);

                

                return View("CompleteOrder");
            }


            return View("CompleteOrder");
        }
        [HttpGet]
        public ActionResult ViewOrder(Orders ord)
        {

           ord = repo.GetOrderById(ord);


            return View(ord);
        }

        [HttpGet]
        public int GetOrderId()
        {


            Orders ord = new Orders();
            ord.CreatedBy = User.Identity.Name;

            


            return repo.GetOrderId(ord);
        }

    }
}
