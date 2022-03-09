﻿using Data;
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
                .FirstOrDefault(f => f.Id == id)
                .ToServiceModel();

            return request;
        }

        public FriendRequestServiceModel AddToDatabase(FriendRequestServiceModel friendRequest)
        {
            FriendRequest frReq = friendRequest.ToEntity();

            db.FriendRequests.Add(frReq);

            db.SaveChanges();

            return friendRequest;
        }

        public FriendRequestServiceModel ApproveFriendRequest(string id)
        {
            FriendRequestServiceModel request = FindFriendRequest(id);
            request.RequestStatus = "Approved";

            db.SaveChanges();

            return request;
        }

        public FriendRequestServiceModel RejectFriendRequest(string id)
        {
            FriendRequestServiceModel request = FindFriendRequest(id);
            request.RequestStatus = "Rejected";

            db.SaveChanges();

            return request;
        }

        public void DeleteFriendRequest(string id)
        {
            FriendRequestServiceModel request = FindFriendRequest(id);

            db.FriendRequests.Remove(request.ToEntity());
            db.SaveChanges();
        }

        public FriendRequestServiceModel SentFriendRequestToUser(User sender, User receiver)
        {
            FriendRequestServiceModel request = new FriendRequestServiceModel();

            request.RequestedFrom = sender;
            request.RequestedFromId = sender.Id;
            request.RequestedTo = receiver;
            request.RequestedToId = sender.Id;
            request.RequestStatus = "Pending";

            AddToDatabase(request);

            return request;
        }
    }
}
