using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class UserServiceModelMapper
    {
        public static UserServiceModel ToUserServiceModel(this User user)
        {
            UserServiceModel result = new UserServiceModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName
            };

            return result;
        }
    }
}
