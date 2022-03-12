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
using Microsoft.EntityFrameworkCore;

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
            FriendRequest request = db.FriendRequests
                .FirstOrDefault(fr => fr.Id == id);

            UserFriend user = new UserFriend()
            {
                User = request.RequestedFrom,
                Friend = request.RequestedTo,
                UserId = request.RequestedFromId,
                FriendId = request.RequestedToId
            };

            UserFriend friend = new UserFriend()
            {
                User = request.RequestedTo,
                Friend = request.RequestedFrom,
                UserId = request.RequestedToId,
                FriendId = request.RequestedFromId
            };

            db.UsersFriends.Add(user);
            db.UsersFriends.Add(friend);

            FriendRequestServiceModel result = UpdateRequestStatus(id, "Approved");

            db.SaveChanges();

            return result;
        }

        public FriendRequestServiceModel RejectFriendRequest(string id)
        {
            FriendRequestServiceModel request = UpdateRequestStatus(id, "Rejected");

            db.SaveChanges();

            return request;
        }

        public FriendRequestServiceModel UpdateRequestStatus(string id, string newStatus)
        {
            FriendRequest request = db.FriendRequests
                .FirstOrDefault(fr => fr.Id == id);

            request.RequestStatus = newStatus;

            db.SaveChanges();

            return request.ToFriendRequestServiceModel();
        }

        public void DeleteFriendRequest(string id)
        {
            FriendRequest request = db.FriendRequests.FirstOrDefault(fr => fr.Id == id);

            db.FriendRequests.Remove(request);
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
                .Include(u => u.RequestedTo)
                .Where(fr => fr.RequestedFromId == senderId && fr.RequestStatus == "Pending")
                .Select(fr => fr.ToFriendRequestServiceModel())
                .ToList();

            return requests;
        }

        public List<FriendRequestServiceModel> GetUserInvitations(string receiverId)
        {
            List<FriendRequestServiceModel> invitations = db.FriendRequests
                .Include(u => u.RequestedFrom)
                .Where(fr => fr.RequestedToId == receiverId && fr.RequestStatus == "Pending")
                .Select(fr => fr.ToFriendRequestServiceModel())
                .ToList();

            return invitations;
        }
    }
}
