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

        //public List<Client> SearchClients(Client cli)
        //{
        //    var queryParameters = new DynamicParameters();
        //    queryParameters.Add("@name", cli.Names);
        //    queryParameters.Add("@price", prod.Price);
        //    queryParameters.Add("@product_type_id", prod.ProductTypeId);
        //    queryParameters.Add("@description", prod.Description);
        //    queryParameters.Add("@req_work", prod.ReqWork);

        //    conn.Query("INSERT_PRODUCT", queryParameters, commandType: System.Data.CommandType.StoredProcedure);

        //}


    }
}
