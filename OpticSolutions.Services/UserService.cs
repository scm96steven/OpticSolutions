﻿using OpticSolutions.Repositories;
using OpticSolutions.Repositories.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticSolutions.Services
{
    public class UserService
    {
       public UserRepository repo = new UserRepository();


        public AppUser GetUserInfoById(string UserName)
        {
            var data = repo.GetUserInfoById(UserName);
            return data;
        }
       

    }
}
