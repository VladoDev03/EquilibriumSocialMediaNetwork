﻿using Data.Entities;
using Data.ViewModels;
using Data.ViewModels.User;
using JsonManager.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonManager
{
    public class JsonUserManager : IJsonUserManager
    {
        public string UserToJson(UserSearchView user)
        {
            string result = JsonSerializer.Serialize(user, new JsonSerializerOptions()
            {
                WriteIndented = true
            });

            return result;
        }

        public UserSearchView JsonToUser(string json)
        {
            UserSearchView user = JsonSerializer.Deserialize<UserSearchView>(json);
            return user;
        }

        public string AllUsersToJson(List<UserSearchView> users)
        {
            string result = JsonSerializer.Serialize(users, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            return result;
        }

        public List<UserSearchView> JsonToListUsers(string json)
        {
            List<UserSearchView> users = JsonSerializer.Deserialize<List<UserSearchView>>(json);
            return users;
        }
    }
}
