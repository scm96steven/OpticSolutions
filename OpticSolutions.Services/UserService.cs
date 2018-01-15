using OpticSolutions.Repositories;
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

        public void EditProfile(AppUser user)
        {
            repo.EditProfile(user);
        }

        public List<Doctor> GetDoctors()
        {
            var data = repo.GetDoctors();

            return data;
        }

        public List<UserViewModel> GetUsers()
        {
            var data = repo.GetUsers();

            return data;
        }

        public UserViewModel GetUserInfo(string UserName)
        {
            var data = repo.GetUserInfo(UserName);
            return data;
        }

        public void DeleteUser(UserViewModel user)
        {
            repo.DeleteUser(user);
        }

    }
}
