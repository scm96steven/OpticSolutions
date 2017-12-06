using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController()
        {
            if (User != null)
            {
                Session["UserFullName"] = User.Identity.Name;
            }

        }
        public ActionResult Index()
        {
            if (HttpContext.User != null)
            {
                Session["UserFullName"] = User.Identity.Name;
            }

            return View();
        }

        public ActionResult AnotherLink()
        {
            return View("Index");
        }




  

   
    }
}
