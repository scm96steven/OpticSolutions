﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using OpticSolutions.Repositories.Entitys;

namespace OpticSolutions.Repositories
{
    public class UserRepository
    {
        public SqlConnection conn = new SqlConnection();

        public UserRepository()
        {
            conn.ConnectionString = "Server=tcp:opticsolutions.database.windows.net,1433;Initial Catalog=OpticSolutions;Persist Security Info=False;User ID=osuser;Password=p@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
    
        }
            


        public AppUser GetUserInfoById(string username)
        {
            conn.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@username", username);

            var data = conn.Query<AppUser>("GET_USER_BY_UN", queryParameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            conn.Close();
            return data;
        }
        public void EditProfile(AppUser user)
        {
            conn.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@firstname", user.FirstName);
            queryParameters.Add("@lastname", user.LastName);
            queryParameters.Add("@phone", user.Phone);
            queryParameters.Add("@userphoto", user.UserPhoto, System.Data.DbType.Binary,System.Data.ParameterDirection.Input, -1);
            queryParameters.Add("@username", user.UserName);

            conn.Query("EDIT_PROFILE", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
            conn.Close();
        }

        public List<Doctor> GetDoctors()
        {
            conn.Open();
            var data = conn.Query<Doctor>("GET_DOCTORS", null, commandType: System.Data.CommandType.StoredProcedure).ToList();
            conn.Close();
            return data;
        }

    }
}
