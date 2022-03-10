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

        FriendRequestServiceModel SentFriendRequestToUser(UserServiceModel sender, UserServiceModel receiver);

        FriendRequestServiceModel ApproveFriendRequest(string id);

        FriendRequestServiceModel RejectFriendRequest(string id);

        List<FriendRequestServiceModel> GetPendingRequests(string senderId);

        List<FriendRequestServiceModel> GetUserInvitations(string receiverId);

        void DeleteFriendRequest(string id);
    }
}
