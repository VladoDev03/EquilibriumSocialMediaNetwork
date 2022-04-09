using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IUserServices
    {
        /// <summary>
        /// Gets all users from the database.
        /// </summary>
        /// <returns>All registered users.</returns>
        List<UserServiceModel> GetUsers();

        /// <summary>
        /// Gets all users that don't have the role of the Admin.
        /// </summary>
        /// <returns>All regular users.</returns>
        List<UserServiceModel> GetUsersExceptAdmins();

        /// <summary>
        /// Gets user by his id.
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>The searched user.</returns>
        UserServiceModel GetUserById(string id);

        /// <summary>
        /// Gets user by his username.
        /// </summary>
        /// <param name="id">User's username</param>
        /// <returns>The searched user.</returns>
        UserServiceModel GetUserByUsername(string username);

        /// <summary>
        /// Gets user by his email address.
        /// </summary>
        /// <param name="id">User's email address.</param>
        /// <returns>The searched user.</returns>
        UserServiceModel GetUserByEmail(string email);

        /// <summary>
        /// Checks if the given user is admin.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <returns>True if the user is admin.</returns>
        bool IsUserAdmin(string userId);

        /// <summary>
        /// Checks if the given user is invited by another user.
        /// </summary>
        /// <param name="loggedUserId">Current user's id.</param>
        /// <param name="userId">Searched user's id.</param>
        /// <returns>True if the current user has an invite from the searched user.</returns>
        bool IsUserInvited(string loggedUserId, string userId);

        /// <summary>
        /// Checks if the given user has invited the current user.
        /// </summary>
        /// <param name="loggedUserId">Current user's id.</param>
        /// <param name="userId">Searched user's id.</param>
        /// <returns>True if the searched user has sent an invitation to the current user.</returns>
        bool HasUserInvitedUs(string loggedUserId, string userId);

        /// <summary>
        /// Checks if the given user is a friend of the current user.
        /// </summary>
        /// <param name="loggedUserId">Current user's id.</param>
        /// <param name="userId">Searched user's id.</param>
        /// <returns>True if the searched user is a friend with the current user.</returns>
        bool IsUserFriend(string loggedUserId, string userId);

        /// <summary>
        /// Removes user from the database.
        /// </summary>
        /// <param name="userId">The searched user's id.</param>
        void DeleteUser(string userId);

        /// <summary>
        /// Makes user an admin.
        /// </summary>
        /// <param name="userId">The searched user's id.</param>
        void MakeUserAdmin(string userId);

        /// <summary>
        /// Confirms the account of the given user.
        /// </summary>
        /// <param name="userId">The searched user's id.</param>
        void ConfirmAccount(string userId);
    }
}
