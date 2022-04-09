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

        public FriendRequestServiceModel ApproveFriendRequest(string sentToId, string sentFromId)
        {
            List<FriendRequest> requests = db.FriendRequests
                .Where(fr => ((fr.RequestedToId == sentToId && fr.RequestedFromId == sentFromId)
                            || fr.RequestedToId == sentFromId && fr.RequestedFromId == sentToId)
                            && fr.RequestStatus != "Pending")

                .ToList();

            db.RemoveRange(requests);
            db.SaveChanges();

            FriendRequestServiceModel requestToApprove = db.FriendRequests
                .FirstOrDefault(fr => fr.RequestedToId == sentToId
                                    && fr.RequestedFromId == sentFromId)
                .ToFriendRequestServiceModel();

            if (requestToApprove.RequestStatus == "Approved")
            {
                return requestToApprove;
            }

            UserFriend user = new UserFriend()
            {
                User = requestToApprove.RequestedFrom,
                Friend = requestToApprove.RequestedTo,
                UserId = requestToApprove.RequestedFromId,
                FriendId = requestToApprove.RequestedToId
            };

            UserFriend friend = new UserFriend()
            {
                User = requestToApprove.RequestedTo,
                Friend = requestToApprove.RequestedFrom,
                UserId = requestToApprove.RequestedToId,
                FriendId = requestToApprove.RequestedFromId
            };

            db.UsersFriends.Add(user);
            db.UsersFriends.Add(friend);

            FriendRequestServiceModel result = UpdateRequestStatus(requestToApprove.Id, "Approved");

            db.SaveChanges();

            return result;
        }

        public FriendRequestServiceModel RejectFriendRequest(string sentToId, string sentFromId)
        {
            List<FriendRequest> requests = db.FriendRequests
                .Where(fr => ((fr.RequestedToId == sentToId && fr.RequestedFromId == sentFromId)
                            || fr.RequestedToId == sentFromId && fr.RequestedFromId == sentToId)
                            && fr.RequestStatus != "Pending")

                .ToList();

            db.RemoveRange(requests);
            db.SaveChanges();

            FriendRequestServiceModel requestToReject = db.FriendRequests
                .FirstOrDefault(fr => fr.RequestedToId == sentToId
                                    && fr.RequestedFromId == sentFromId)
                .ToFriendRequestServiceModel();

            if (requestToReject.RequestStatus == "Rejected")
            {
                return requestToReject;
            }

            FriendRequestServiceModel result = UpdateRequestStatus(requestToReject.Id, "Rejected");

            db.SaveChanges();

            return result;
        }

        public FriendRequestServiceModel UpdateRequestStatus(string requestId, string newStatus)
        {
            FriendRequest request = db.FriendRequests
                .FirstOrDefault(fr => fr.Id == requestId);

            request.RequestStatus = newStatus;

            db.SaveChanges();

            return request.ToFriendRequestServiceModel();
        }

        public void DeleteFriendRequest(string sentFromId, string sentToId)
        {
            FriendRequest result = db.FriendRequests
                .FirstOrDefault(fr => fr.RequestedFromId == sentFromId
                                    && fr.RequestedToId == sentToId);

            db.FriendRequests.Remove(result);
            db.SaveChanges();
        }

        public FriendRequestServiceModel SendFriendRequestToUser(UserServiceModel sender, UserServiceModel receiver)
        {
            FriendRequestServiceModel request = new FriendRequestServiceModel();

            request.RequestedFromId = sender.Id;
            request.RequestedToId = receiver.Id;
            request.RequestStatus = "Pending";

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

        public void DeleteAllFriendRequestBySenderId(string id)
        {
            List<FriendRequest> friendRequests = db.FriendRequests
                .Where(fr => fr.RequestedFromId == id)
                .ToList();

            db.FriendRequests.RemoveRange(friendRequests);

            db.SaveChanges();
        }

        public void DeleteAllFriendRequestByReveiverId(string id)
        {
            List<FriendRequest> friendRequests = db.FriendRequests
                   .Where(fr => fr.RequestedToId == id)
                   .ToList();

            db.FriendRequests.RemoveRange(friendRequests);

            db.SaveChanges();
        }
    }
}
