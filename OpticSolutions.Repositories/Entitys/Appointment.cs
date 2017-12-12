﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Repositories.Entitys
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string Cedula { get; set; }
        public string CellPhone { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
