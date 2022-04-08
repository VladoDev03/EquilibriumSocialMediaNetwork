﻿using Data.Entities;
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

        UserServiceModel GetUserByUsername(string username);

        UserServiceModel GetUserByEmail(string email);

        bool IsUserAdmin(string userId);

        bool IsUserInvited(string loggedUserId, string userId);

        bool HasUserInvitedUs(string loggedUserId, string userId);

        bool IsUserFriend(string loggedUserId, string userId);

        void DeleteUser(string userId);

        void MakeUserAdmin(string userId);

        void ConfirmAccount(string userId);
    }
}
