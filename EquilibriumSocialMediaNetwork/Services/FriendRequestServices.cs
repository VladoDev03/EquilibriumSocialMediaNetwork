using Data;
using Data.Entities;
using Services.Contracts;
using Services.Models;
using System;
using Services.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FriendRequestServices : IFriendRequestServices
    {
        private EquilibriumDbContext db;

        public FriendRequestServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public FriendRequestServiceModel FindFriendRequest(string id)
        {
            FriendRequestServiceModel request = db.FriendRequests
                .FirstOrDefault(fr => fr.Id == id)
                .ToFriendRequestServiceModel();

            return request;
        }

        public FriendRequestServiceModel AddToDatabase(FriendRequestServiceModel friendRequest)
        {
            FriendRequest frReq = friendRequest.ToFriendRequest();

            db.FriendRequests.Add(frReq);

            db.SaveChanges();

            return friendRequest;
        }

        public FriendRequestServiceModel ApproveFriendRequest(string id)
        {
            FriendRequestServiceModel request = FindFriendRequest(id);
            request.RequestStatus = "Approved";

            UserFriend userFriend = new UserFriend()
            {
                User = request.RequestedFrom,
                Friend = request.RequestedTo,
                UserId = request.RequestedToId,
                FriendId = request.RequestedToId
            };

            db.UsersFriends.Add(userFriend);

            db.SaveChanges();

            return request;
        }

        public FriendRequestServiceModel RejectFriendRequest(string id)
        {
            FriendRequestServiceModel request = FindFriendRequest(id);
            request.RequestStatus = "Rejected";

            //Delete request from database?

            db.SaveChanges();

            return request;
        }

        public void DeleteFriendRequest(string id)
        {
            FriendRequestServiceModel request = FindFriendRequest(id);

            db.FriendRequests.Remove(request.ToFriendRequest());
            db.SaveChanges();
        }

        public FriendRequestServiceModel SentFriendRequestToUser(UserServiceModel sender, UserServiceModel receiver)
        {
            FriendRequestServiceModel request = new FriendRequestServiceModel();

            //request.RequestedFrom = sender.ToUser();
            request.RequestedFromId = sender.Id;
            //request.RequestedTo = receiver.ToUser();
            request.RequestedToId = receiver.Id;
            request.RequestStatus = "Pending";

            //AddToDatabase(request)

            FriendRequest frReq = request.ToFriendRequest();
            db.FriendRequests.Add(frReq);

            db.SaveChanges();

            return request;
        }

        public List<FriendRequestServiceModel> GetPendingRequests(string senderId)
        {
            List<FriendRequestServiceModel> requests = db.FriendRequests
                .Where(fr => fr.RequestedFromId == senderId)
                .Select(fr => fr.ToFriendRequestServiceModel())
                .ToList();

            return requests;
        }

        public List<FriendRequestServiceModel> GetUserInvitations(string receiverId)
        {
            List<FriendRequestServiceModel> invitations = db.FriendRequests
                   .Where(fr => fr.RequestedToId == receiverId)
                   .Select(fr => fr.ToFriendRequestServiceModel())
                   .ToList();

            return invitations;
        }
    }
}
