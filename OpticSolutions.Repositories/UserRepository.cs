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
            conn.Open();
    
        }
            


        public AppUser GetUserInfoById(string username)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@username", username);

            var data = conn.Query<AppUser>("GET_USER_INFO", queryParameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();

            return data;
        }


    }
}
