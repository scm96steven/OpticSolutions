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
    public class ClientRepository
    {
        public SqlConnection conn = new SqlConnection();

        public ClientRepository()
        {
            conn.ConnectionString = "Server=tcp:opticsolutions.database.windows.net,1433;Initial Catalog=OpticSolutions;Persist Security Info=False;User ID=osuser;Password=p@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            conn.Open();

            var data = conn.Query<Client>("SELECT * FROM CLIENTS").ToList();
    
        }

        public List<Client> SearchClients(Client cli)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@names", cli.Names);
            queryParameters.Add("@last_names", cli.Last_Names);
            queryParameters.Add("@email", cli.Email);
            queryParameters.Add("@phone", cli.Phone);
            queryParameters.Add("@cedula", cli.IdentificationCard);

            var data = conn.Query<Client>("SEARCH_CLIENTS", queryParameters, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return data;
        }

        public void CreateClient(Client cli)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@names", cli.Names);
            queryParameters.Add("@last_names", cli.Last_Names);
            queryParameters.Add("@email", cli.Email);
            queryParameters.Add("@phone", cli.Phone);
            queryParameters.Add("@address", cli.Address);
            queryParameters.Add("@cedula", cli.IdentificationCard);

            conn.Query("CREATE_CLIENT", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public void CreateRecord(Consult con)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@date", con.Date);
            queryParameters.Add("@doctor_user_name", con.DoctorUserName);
            queryParameters.Add("@client_id", con.Client.ClientId);
            queryParameters.Add("@description", con.Description);

        
            conn.Query("CREATE_RECORD", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
        }


    }
}
