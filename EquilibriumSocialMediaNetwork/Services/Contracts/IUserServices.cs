using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserServices
    {
        List<UserServiceModel> GetUsers();

        List<UserServiceModel> GetUsersExceptAdmins();

        UserServiceModel GetUserById(string id);

        void DeleteUser(string userId);
    }
}
