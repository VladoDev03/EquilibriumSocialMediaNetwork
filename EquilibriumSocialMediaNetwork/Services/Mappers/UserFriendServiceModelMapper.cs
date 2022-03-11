using Data.Entities;
using Data.ViewModels.UserFriend;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class UserFriendServiceModelMapper
    {
        public static UserFriendServiceModel ToUserFriendServiceModel(this UserFriend userFriend)
        {
            UserFriendServiceModel result = new UserFriendServiceModel()
            {
                Friend = userFriend.Friend,
                User = userFriend.User,
                FriendId = userFriend.FriendId,
                UserId = userFriend.UserId
            };

            return result;
        }

        public static UserFriend ToUserFriend(this UserFriendServiceModel userFriend)
        {
            UserFriend result = new UserFriend()
            {
                Friend = userFriend.Friend,
                User = userFriend.User,
                FriendId = userFriend.FriendId,
                UserId = userFriend.UserId
            };

            return result;
        }

        public static UserFriendViewModel ToUserFriendViewModel(this UserFriendServiceModel userFriend)
        {
            UserFriendViewModel result = new UserFriendViewModel()
            {
                Friend = userFriend.Friend.ToUserViewModel(),
                User = userFriend.User.ToUserViewModel(),
                FriendId = userFriend.FriendId,
                UserId = userFriend.UserId
            };

            return result;
        }
    }
}
