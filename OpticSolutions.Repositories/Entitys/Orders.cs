using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Repositories.Entitys
{
    public class Orders
    {
        public int order_det_id { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int price { get; set; }
        public int status_id { get; set; }
        public string status_desc { get; set; }
        public int order_status_id { get; set; }
        public DateTime date { get; set; }
        public int client_id { get; set; }

    }
}
