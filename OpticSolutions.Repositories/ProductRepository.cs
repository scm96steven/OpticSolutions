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
    public class ProductRepository
    {
        public SqlConnection conn = new SqlConnection();

        public ProductRepository()
        {
            conn.ConnectionString = "Server=tcp:opticsolutions.database.windows.net,1433;Initial Catalog=OpticSolutions;Persist Security Info=False;User ID=osuser;Password=p@ssw0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            conn.Open();
    
        }
            

        public List<Product> GetProductsList()
        {
            var data = conn.Query<Product>("GET_PRODUCTS", null, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return data;
        }


        public List<ProductType> GetProductTypeList()
        {
            var data = conn.Query<ProductType>("GET_PRODUCT_TYPES", null, commandType: System.Data.CommandType.StoredProcedure).ToList();

            return data;
        }


        public void CreateProduct( Product prod)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@name", prod.Name);
            queryParameters.Add("@price", prod.Price);
            queryParameters.Add("@product_type_id",prod.ProductTypeId);
            queryParameters.Add("@description", prod.Description);
            queryParameters.Add("@req_work", prod.ReqWork);

            conn.Query("INSERT_PRODUCT", queryParameters, commandType:System.Data.CommandType.StoredProcedure);

        }

        public void DeleteProduct(Product prod)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@product_id", prod.ProductId);

            conn.Query("DELETE_PRODUCT", queryParameters, commandType: System.Data.CommandType.StoredProcedure);

        }

        public Product GetProductById(Product prod)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@product_id", prod.ProductId);

            var data = conn.Query<Product>("GET_PRODUCT_BY_ID", queryParameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            return data;
        }

        public void EditProduct(Product prod)
        {
            var queryParameters = new DynamicParameters();
            queryParameters.Add("@name", prod.Name);
            queryParameters.Add("@price", prod.Price);
            queryParameters.Add("@product_type_id", prod.ProductTypeId);
            queryParameters.Add("@description", prod.Description);
            queryParameters.Add("@req_work", prod.ReqWork);
            queryParameters.Add("@productid", prod.ProductId);

            var data = conn.Query<Product>("EDIT_PRODUCT", queryParameters, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
            
        }

       /* public List<PendingWork> GetPendingWork()
        {
            
            var data = conn.Query<PendingWork>("GET_PENDING_WORK",null, 
                commandType: System.Data.CommandType.StoredProcedure).ToList();


            return data;
        }*/

    }
}
