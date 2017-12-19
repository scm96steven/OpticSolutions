using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticSolutions.ViewModels
{
    public class ProfileMenuViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public byte[] UserPhoto { get; set; }
    }
}