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

        FriendRequestServiceModel ApproveFriendRequest(string sentToId, string sentFromId);

        FriendRequestServiceModel RejectFriendRequest(string sentToId, string sentFromId);

        FriendRequestServiceModel UpdateRequestStatus(string requestId, string newStatus);

        List<FriendRequestServiceModel> GetPendingRequests(string senderId);

        List<FriendRequestServiceModel> GetUserInvitations(string receiverId);

        void DeleteFriendRequest(string sentFromId, string sentToId);

        void DeleteAllFriendRequestBySenderId(string id);

        void DeleteAllFriendRequestByReveiverId(string id);
    }
}
