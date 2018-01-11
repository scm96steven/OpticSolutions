using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Repositories.Entitys
{
    public class PendingWork
    {
        public DateTime AssignDate { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }

        public string ClientName { get; set; }
        public string Phone { get; set; }

        public int OrderId { get; set; }
        
    }
}
