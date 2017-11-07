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

    }
}
