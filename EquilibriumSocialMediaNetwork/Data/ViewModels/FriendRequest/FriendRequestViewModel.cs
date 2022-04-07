using Data.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.FriendRequest
{
    public class FriendRequestViewModel
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public UserViewModel RequestedFrom { get; set; }

        public UserViewModel RequestedTo { get; set; }
    }
}
