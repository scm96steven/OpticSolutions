using OpticSolutions.Repositories;
using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Services
{
    public class AppointmentService
    {
       public AppointmentRepository repo = new AppointmentRepository();



        public List<Appointment> GetAppointments(Appointment ap)
        {

          var data = repo.GetAppointments(ap);

            return data;
         }

        public List<Appointment> GetAllAppointments()
        {
            var data = repo.GetAllAppointments();

            return data;
        }


        public void CreateAppointment(Appointment ap)
        {
            repo.CreateAppointment(ap);
        }

        public int CheckAppointments(Appointment ap)
        {
           var data = repo.CheckAppointments(ap);
            return data;
        }

        public void DeleteAppointment(Appointment ap)
        {
            repo.DeleteAppointment(ap);
        }
    }

}
