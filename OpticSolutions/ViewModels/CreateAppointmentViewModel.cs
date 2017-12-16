using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticSolutions.ViewModels
{
    public class CreateAppointmentViewModel
    {
        public Appointment Appointment{ get; set; }
        public List<Appointment> ApList { get; set; }

    }
}