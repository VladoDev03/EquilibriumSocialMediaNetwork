using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonManager.Contracts
{
    public interface IJsonUserManager
    {
        string UserToJson(UserSearchView user);

        string AllUsersToJson(List<UserSearchView> users);

        UserSearchView JsonToUser(string json);

        List<UserSearchView> JsonToListUsers(string json);
    }
}
