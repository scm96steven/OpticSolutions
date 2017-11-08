using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Repositories.Entitys
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Names { get; set; }
        public string Last_Names { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IdentificationCard { get; set; }
        public string Address { get; set; }

    }
}
