﻿using Microsoft.AspNet.Identity.EntityFramework;
using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpticSolutions.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("OSConnection")
        {
        }
    }
}