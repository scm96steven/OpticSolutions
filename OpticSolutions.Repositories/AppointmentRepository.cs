using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using OpticSolutions.Repositories.Entitys;

namespace OpticSolutions.Repositories
{
    public class AppointmentRepository
    {
        public SqlConnection conn = new SqlConnection();

        public AppointmentRepository()
        {
            conn.ConnectionString = "Server=tcp:opticsolutions.database.windows.net,1433;Initial Catalog=OpticSolutions;Persist Security Info=False;User ID=osuser;Password=p@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            conn.Open();
    
        }
         

        public List<Appointment> GetAppointments(Appointment ap)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@date", ap.Date);
            queryParameters.Add("@doctor_id", ap.DoctorId);


            var data = conn.Query<Appointment>("GET_APPOINTMENTS", queryParameters, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return data;
        }



    }
}
