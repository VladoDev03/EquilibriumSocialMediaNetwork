using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserFriendServices
    {
        /// <summary>
        /// Gets all friends of a given user's id.
        /// </summary>
        /// <param name="userId">Id of the user.</param>
        /// <returns>All user's friends.</returns>
        List<UserFriendServiceModel> GetUserFriends(string userId);

        /// <summary>
        /// Removes a user from the given user's friend list.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <param name="friendId">Friend's id.</param>
        void RemoveUserFriend(string userId, string friendId);

        /// <summary>
        /// Removes all friends of a given user.
        /// </summary>
        /// <param name="userId">User's id.</param>
        void RemoveAllFriends(string userId);
    }
}
