using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Repositories.Entitys
{
    public class Client
    {

        public int ClientId { get; set; }

        [Required(ErrorMessage = "El campo nombres es requerido")]
        public string Names { get; set; }

        [Required(ErrorMessage = "El campo apellidos es requerido")]
        public string Last_Names { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo telefono es requerido")]
        public string Phone { get; set; }

  
        public string IdentificationCard { get; set; }

        [Required(ErrorMessage = "El campo direccion es requerido")]
        public string Address { get; set; }

    }
}
