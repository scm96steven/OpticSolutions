﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using OpticSolutions.Repositories.Entitys;
using System.Data;

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
            queryParameters.Add("@doctor_username", ap.DoctorUsername);

            var data = conn.Query<Appointment>("GET_APPOINTMENTS", queryParameters, commandType: System.Data.CommandType.StoredProcedure).ToList();



            return data;
        }

        public List<Appointment> GetAllAppointments(Appointment ap)
        {
            var data = conn.Query<Appointment>("GET_ALL_APPOINTMENTS", null, commandType: System.Data.CommandType.StoredProcedure).ToList();



            return data;
        }

        public void CreateAppointment(Appointment ap)
        {
            ap.EndDate = ap.StartDate.AddMinutes(29);
          
            ap.Date = DateTime.Now;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@date", ap.Date);
            queryParameters.Add("@doctor_username", ap.DoctorUsername);
            queryParameters.Add("@names", ap.Names);
            queryParameters.Add("@last_names", ap.Last_Names);
            queryParameters.Add("@email", ap.Email);
            queryParameters.Add("@phone", ap.Phone);
            queryParameters.Add("@cedula", ap.IdentificationCard);
            queryParameters.Add("@comment", ap.Comment);
            queryParameters.Add("@start_date", ap.StartDate);
            queryParameters.Add("@end_date", ap.EndDate);

             conn.Query("CREATE_APPOINTMENTS", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
            
        }

        public int CheckAppointments(Appointment ap)
        {
            ap.EndDate = ap.StartDate.AddMinutes(29);
            ap.EndDate = ap.StartDate.AddSeconds(59);
            ap.Date = DateTime.Now;

            var queryParameters = new DynamicParameters();
            queryParameters.Add("@startdate", ap.StartDate);
            queryParameters.Add("@enddate", ap.EndDate);
            queryParameters.Add("@doctor_username", ap.DoctorUsername);
            queryParameters.Add("@num_of_app", dbType: DbType.Int32, direction: ParameterDirection.Output);


            conn.Query("CHECK_APPOINTMENTS", queryParameters, commandType: System.Data.CommandType.StoredProcedure);

            var data = queryParameters.Get<int>("@num_of_app");

            return data;

        }


    }
}
