using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserFriendServices
    {
        List<UserFriendServiceModel> GetUserFriends(string userId);

        void RemoveUserFriend(string userId, string friendId);

        void RemoveAllFriends(string userId);
    }
}
