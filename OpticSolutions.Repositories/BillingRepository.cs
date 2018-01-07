using Dapper;
using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Repositories
{
     public class BillingRepository
    {
        public SqlConnection con = new SqlConnection();

        public BillingRepository()
        {
            con.ConnectionString = "Server=tcp:opticsolutions.database.windows.net,1433;Initial Catalog=OpticSolutions;Persist Security Info=False;User ID=osuser;Password=p@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            
        }

        public Orders ShowOrderDetails(Orders Or)
        {
            con.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@order_id", Or.OrderId);
            //queryParameters.Add("@order_status_id", Or.order_status_id);
            //queryParameters.Add("@date", Or.date);
            //queryParameters.Add("@client_id", Or.client_id);
            //queryParameters.Add("@status_id", Or.status_id);
            //queryParameters.Add("@status_desc", Or.status_desc);
            //queryParameters.Add("@order_det_id", Or.order_det_id);
            //queryParameters.Add("@product_id", Or.product_id);
            //queryParameters.Add("@price", Or.price);


          
            var data = con.Query<Orders>("SHOW_ORDER_DETAILS", null, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            con.Close();
            return data;

        }

        public Orders ShowOrders(Orders Or)
        {
            con.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@order_id", Or.OrderId);
            //queryParameters.Add("@order_status_id", Or.order_status_id);
            //queryParameters.Add("@date", Or.date);
            //queryParameters.Add("@client_id", Or.client_id);
            //queryParameters.Add("@status_id", Or.status_id);
            //queryParameters.Add("@status_desc", Or.status_desc);
            //queryParameters.Add("@order_det_id", Or.order_det_id);
            //queryParameters.Add("@product_id", Or.product_id);
            //queryParameters.Add("@price", Or.price);



            var data = con.Query<Orders>("SHOW_ORDERS", null, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            con.Close();
            return data;

        }
 
        public void CreateOrder(Orders Ord)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@date",Ord.CreatedDate);

            con.Query<Orders>("CREATE_ORDER", queryParameters, commandType: System.Data.CommandType.StoredProcedure);

            foreach (var item in Ord.OrderDetails)
            {
                con.Query<Orders>("CREATE_ORDER_DETAIL", null, commandType: System.Data.CommandType.StoredProcedure);
            }

        }

    }
}
