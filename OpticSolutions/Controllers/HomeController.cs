using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController()
        {
           
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }




  

   
    }
}
