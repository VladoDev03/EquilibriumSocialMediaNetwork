using Data.Entities;
using Data.ViewModels.FriendRequest;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class FriendRequestServiceModelMapper
    {
        public static FriendRequestServiceModel ToFriendRequestServiceModel(this FriendRequest request)
        {
            FriendRequestServiceModel result = new FriendRequestServiceModel()
            {
                Id = request.Id,
                RequestStatus = request.RequestStatus,
                RequestedFrom = request.RequestedFrom,
                RequestedFromId = request.RequestedFromId,
                RequestedTo = request.RequestedTo,
                RequestedToId = request.RequestedToId
            };

            return result;
        }

        public static FriendRequest ToFriendRequest(this FriendRequestServiceModel request)
        {
            FriendRequest result = new FriendRequest()
            {
                Id = request.Id,
                RequestStatus = request.RequestStatus,
                RequestedFrom = request.RequestedFrom,
                RequestedFromId = request.RequestedFromId,
                RequestedTo = request.RequestedTo,
                RequestedToId = request.RequestedToId
            };

            return result;
        }

        public static FriendRequestViewModel ToFriendRequestViewModel(this FriendRequestServiceModel request)
        {
            FriendRequestViewModel result = new FriendRequestViewModel()
            {
                Id = request.Id,
                Status = request.RequestStatus,
                RequestedFrom = request.RequestedFrom.ToUserViewModel(),
                RequestedTo = request.RequestedTo.ToUserViewModel()
            };

            return result;
        }
    }
}
