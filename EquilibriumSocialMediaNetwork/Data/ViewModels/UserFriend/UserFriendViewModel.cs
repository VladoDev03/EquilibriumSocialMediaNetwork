using Data.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.UserFriend
{
    public class UserFriendViewModel
    {
        public string UserId { get; set; }

        public string FriendId { get; set; }

        public UserViewModel User { get; set; }

        public UserViewModel Friend { get; set; }
    }
}
