using Dapper;
using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Data;
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
            con.Open();
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@date",Ord.CreatedDate);
            queryParameters.Add("@created_by", Ord.CreatedBy);

            con.Query<Orders>("CREATE_ORDER", queryParameters, commandType: System.Data.CommandType.StoredProcedure);

            Ord.OrderId = GetOrderId(Ord);

            foreach (var item in Ord.OrderDetails)
            {

                queryParameters = new DynamicParameters();
            
                queryParameters.Add("@order_id", Ord.OrderId);
                queryParameters.Add("@product_id", item.ProductId);
                queryParameters.Add("@quantity", item.Quantity);
               queryParameters.Add("@price", item.Price);


                con.Query<Orders>("CREATE_ORDER_DETAIL", queryParameters, commandType: System.Data.CommandType.StoredProcedure);
            }

            con.Close();

        }

        public int GetOrderId(Orders Ord)
        {


            var queryParameters = new DynamicParameters();
  
            queryParameters.Add("@doctor_username", Ord.CreatedBy);
            queryParameters.Add("@order_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            con.Query<Orders>("GET_ORDER_ID", queryParameters, commandType: System.Data.CommandType.StoredProcedure);


            var data = queryParameters.Get<int>("@order_id");
      
            return data;
        }

        public Orders GetOrderById(Orders ord)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@order_id",ord.OrderId);

            var list = con.Query<Orders>("GET_ORDER_BY_ID", queryParameters, commandType: System.Data.CommandType.StoredProcedure).ToList();
            var productList = con.Query<Product>("GET_ORDER_BY_ID", queryParameters, commandType: System.Data.CommandType.StoredProcedure).ToList();

            Orders order = list.FirstOrDefault();
            order.OrderDetails = productList;
            ord.Total = 0;

            foreach (Product item in order.OrderDetails)
            {
                order.Total = order.Total + (item.Quantity * item.Price);
            }


            return order;
        }

    }

          

}
