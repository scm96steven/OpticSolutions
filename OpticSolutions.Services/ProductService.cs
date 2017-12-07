using OpticSolutions.Repositories;
using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Services
{
    public class ProductService
    {
       public ProductRepository repo = new ProductRepository();

        public List<Product>  GetProducts()
        {
           var data = repo.GetProductsList();
            return data;
        }
        public void CreateProduct(Product prod)
        {
            repo.CreateProduct(prod);
         
        }

        public void DeleteProduct(Product prod)
        {
            repo.DeleteProduct(prod);

        }

        public Product GetProductById(Product prod)
        {
          var data =  repo.GetProductById(prod);

            return data;
        }

        public void EditProduct(Product prod)
        {
            repo.EditProduct(prod);

        }
/*
        public List<PendingWork> GetPendingWork()
        {
            var data = repo.GetPendingWork();

            return data;
        }*/

    }
}
