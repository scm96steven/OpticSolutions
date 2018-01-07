using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Repositories.Entitys
{
    public class Orders
    {

        public int OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public Client Client { get; set; }
        public List<Product> OrderDetails { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusDesc { get; set; }


       

    }
}
