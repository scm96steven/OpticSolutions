using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class HomeController : Controller
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


        public ActionResult ProfileMenu()
        {
            return View("ProfileMenu");
        }

        public ActionResult ConsultaCliente()
        {
            return View("ConsultaCliente");
        }

        public ActionResult HistorialCliente()
        {
            return View("HistorialCliente");
        }

   
    }
}
