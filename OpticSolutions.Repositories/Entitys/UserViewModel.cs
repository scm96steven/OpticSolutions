using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Repositories.Entitys
{
    public class UserViewModel
    {

      
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Role { get; set; }
            public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
        public string Phone { get; set; }
   
            public string FullName()
            {
                return FirstName + " " + LastName;
            }

        
    }
}
