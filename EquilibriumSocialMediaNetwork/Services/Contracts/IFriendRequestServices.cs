using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IFriendRequestServices
    {
        FriendRequestServiceModel FindFriendRequest(string id);

        FriendRequestServiceModel AddToDatabase(FriendRequestServiceModel friendRequest);

        FriendRequestServiceModel SentFriendRequestToUser(User sender, User receiver);

        FriendRequestServiceModel ApproveFriendRequest(string id);

        FriendRequestServiceModel RejectFriendRequest(string id);

        void DeleteFriendRequest(string id);
    }
}
