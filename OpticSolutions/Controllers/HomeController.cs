using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class HomeController : Controller
    {
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
