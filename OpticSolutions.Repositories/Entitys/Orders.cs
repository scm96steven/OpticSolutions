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
        public string OrderStatusDescription { get; set; }
        public string CreatedBy { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int Total { get; set; }

        public Orders()
        {
            OrderDetails = new List<Product>();

        }


    }
}
