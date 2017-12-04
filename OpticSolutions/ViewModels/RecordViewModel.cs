using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticSolutions.ViewModels
{
    public class RecordViewModel
    {

        public List<Consult> Records { get; set; }
        public Client Client { get; set; }

    }
}