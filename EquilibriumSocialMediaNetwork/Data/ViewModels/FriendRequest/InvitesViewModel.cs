using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.FriendRequest
{
    public class InvitesViewModel
    {
        public List<FriendRequestViewModel> Invites { get; set; }

        public List<FriendRequestViewModel> Pending { get; set; }
    }
}
