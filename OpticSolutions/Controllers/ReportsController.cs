using OpticSolutions.Services;
using OpticSolutions.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticSolutions.Controllers
{
    public class ReportsController : Controller
    {

        ReportService repo;
        public ReportsController()
        {
            repo = new ReportService();
        }

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateReport(ReportViewModel rep)
        {
            var data = repo.GetReportData(rep);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}