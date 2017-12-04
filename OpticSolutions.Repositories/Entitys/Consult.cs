using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Repositories.Entitys
{
   public class Consult
    {

        [Required]
        public DateTime Date { get; set; }
        

        [Required]
        public string DoctorUserName { get; set; }

        public Client Client { get; set; }

        [Required]
        public string Description { get; set; }


    }
}
