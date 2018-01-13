using OpticSolutions.Repositories;
using OpticSolutions.Repositories.Entitys;
using OpticSolutions.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Services
{
    public class ReportService
    {
        public ReportRepository repo = new ReportRepository();

        public List<ReportObject> GetReportData(ReportViewModel rep)
        {
            var data = repo.GetReportData(rep);

            return data;
        }

    }

}
