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
        /// <summary>
        /// Finds a friend request by its id.
        /// </summary>
        /// <param name="id">The friend request's id</param>
        /// <returns>The searched friend request.</returns>
        FriendRequestServiceModel FindFriendRequest(string id);

        /// <summary>
        /// Adds friend requests to the database.
        /// </summary>
        /// <param name="friendRequest"></param>
        /// <returns>The added friend request.</returns>
        FriendRequestServiceModel AddToDatabase(FriendRequestServiceModel friendRequest);

        /// <summary>
        /// Sends friend request from one user to another user.
        /// </summary>
        /// <param name="sender">The user who sent the request.</param>
        /// <param name="receiver">The user the request was sent to.</param>
        /// <returns>The sent friend request.</returns>
        FriendRequestServiceModel SendFriendRequestToUser(UserServiceModel sender, UserServiceModel receiver);

        /// <summary>
        /// Approves friend request by sender id and recceiver id.
        /// </summary>
        /// <param name="sentToId">Id of the user the request was sent to.</param>
        /// <param name="sentFromId">Id of the user who sent the request.</param>
        /// <returns>The approved friend request.</returns>
        FriendRequestServiceModel ApproveFriendRequest(string sentToId, string sentFromId);

        /// <summary>
        /// Rejects friend request by sender id and receiver id.
        /// </summary>
        /// <param name="sentToId">Id of the user the request was sent to.</param>
        /// <param name="sentFromId">Id of the user who sent the request.</param>
        /// <returns>The rejected friend request.</returns>
        FriendRequestServiceModel RejectFriendRequest(string sentToId, string sentFromId);

        /// <summary>
        /// Updates the status of a friend request - ("Pending", "Rejected", "Approved")
        /// </summary>
        /// <param name="requestId">Id of the friend request.</param>
        /// <param name="newStatus">The new status of the friend request.</param>
        /// <returns>The updated friend request.</returns>
        FriendRequestServiceModel UpdateRequestStatus(string requestId, string newStatus);

        /// <summary>
        /// Gets all friend requests with status "Pending" of the given user.
        /// </summary>
        /// <param name="senderId">The id of the sender.</param>
        /// <returns>All pending friend requests of the given user.</returns>
        List<FriendRequestServiceModel> GetPendingRequests(string senderId);

        /// <summary>
        /// Gets all invites sent to the given user.
        /// </summary>
        /// <param name="receiverId">The id of the receiver.</param>
        /// <returns>All invites an user has.</returns>
        List<FriendRequestServiceModel> GetUserInvitations(string receiverId);

        /// <summary>
        /// Removes request by the sender's and receiver's ids.
        /// </summary>
        /// <param name="sentFromId">Sender id.</param>
        /// <param name="sentToId">Receiver id.</param>
        void DeleteFriendRequest(string sentFromId, string sentToId);

        /// <summary>
        /// Removes all requests by theirs sender id.
        /// </summary>
        /// <param name="id">Sender id.</param>
        void DeleteAllFriendRequestBySenderId(string id);

        /// <summary>
        /// Removes all requests by theirs receiver id.
        /// </summary>
        /// <param name="id">Receiver id.</param>
        void DeleteAllFriendRequestByReveiverId(string id);
    }
}
