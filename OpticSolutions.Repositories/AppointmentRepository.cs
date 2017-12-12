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

        public void CreateAppointment(Appointment ap)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@names", ap.Names);
            queryParameters.Add("@last_names", ap.LastNames);
            queryParameters.Add("@email", ap.Email);
            queryParameters.Add("@phone", ap.Phone);
            queryParameters.Add("@cedula", ap.Cedula);
            queryParameters.Add("@comment", ap.Comment);
            queryParameters.Add("@date", DateTime.Now);
            queryParameters.Add("@start_date", ap.StartDate);
            queryParameters.Add("@end_date", ap.EndDate);

            conn.Query("CREATE_APPOINTMENT", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
        }


    }
}
