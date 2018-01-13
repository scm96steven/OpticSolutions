using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticSolutions.ViewModels
{
    public class ReportViewModel
    {


       public DateTime StartDate { get; set; }
       public DateTime EndDate { get; set; }
        public string TypeOfReport { get; set; }
        public string TimeSkip { get; set; }


    }
}