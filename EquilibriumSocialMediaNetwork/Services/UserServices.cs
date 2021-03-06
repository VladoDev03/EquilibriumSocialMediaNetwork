using Data;
using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserServices : IUserServices
    {
        private EquilibriumDbContext db;

        public UserServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public List<UserServiceModel> GetUsers()
        {
            return db.Users
                .Select(u => u.ToUserServiceModel())
                .ToList();
        }

        public UserServiceModel GetUserById(string id)
        {
            UserServiceModel user = db.Users
                .FirstOrDefault(u => u.Id == id)
                .ToUserServiceModel();

            db.SaveChanges();

            return user;
        }

        public UserServiceModel GetUserByUsername(string username)
        {
            UserServiceModel user = db.Users
                .FirstOrDefault(u => u.UserName == username)
                .ToUserServiceModel();

            db.SaveChanges();

            return user;
        }

        public UserServiceModel GetUserByEmail(string email)
        {
            UserServiceModel user = db.Users
                .FirstOrDefault(u => u.Email == email)
                .ToUserServiceModel();

            db.SaveChanges();

            return user;
        }

        public void DeleteUser(string userId)
        {
            User userToRemove = db.Users.FirstOrDefault(u => u.Id == userId);

            db.Users.Remove(userToRemove);

            db.SaveChanges();
        }

        public List<UserServiceModel> GetUsersExceptAdmins()
        {
            IdentityRole role = db.Roles
                .FirstOrDefault(r => r.Name == "Admin");

            string roleId = role.Id;

            List<string> adminIds = db.UserRoles
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => ur.UserId)
                .ToList();

            List<UserServiceModel> notAdminUsers = GetUsers()
                .Where(u => !adminIds.Contains(u.Id))
                .ToList();

            return notAdminUsers;
        }

        public bool IsUserInvited(string loggedUserId, string userId)
        {
            bool isReceiver = db.FriendRequests
                .Any(fr => fr.RequestedFromId == loggedUserId
                    && fr.RequestedToId == userId
                    && fr.RequestStatus == "Pending");

            return isReceiver;
        }

        public bool HasUserInvitedUs(string loggedUserId, string userId)
        {
            bool isSender = db.FriendRequests
                .Any(fr => fr.RequestedToId == loggedUserId
                    && fr.RequestedFromId == userId
                    && fr.RequestStatus == "Pending");

            return isSender;
        }

        public bool IsUserFriend(string loggedUserId, string userId)
        {
            bool isFriend = db.UsersFriends.FirstOrDefault(ur => ur.UserId == loggedUserId && ur.FriendId == userId) != null;
            bool isUser = db.UsersFriends.FirstOrDefault(ur => ur.FriendId == loggedUserId && ur.UserId == userId) != null;

            bool result = isFriend && isUser;

            return result;
        }

        public bool IsUserAdmin(string userId)
        {
            string adminRoleId = db.Roles.FirstOrDefault(r => r.Name == "Admin").Id;

            bool isAdmin = db.UserRoles
                .Where(u => u.UserId == userId)
                .Any(u => u.RoleId == adminRoleId);

            return isAdmin;
        }

        public void MakeUserAdmin(string userId)
        {
            string adminRoleId = db.Roles.FirstOrDefault(r => r.Name == "Admin").Id;

            db.UserRoles.Add(new IdentityUserRole<string>()
            {
                RoleId = adminRoleId,
                UserId = userId
            });

            db.SaveChanges();
        }

        public void ConfirmAccount(string userId)
        {
            User user = db.Users.FirstOrDefault(u => u.Id == userId);

            if (user.EmailConfirmed)
            {
                return;
            }

            user.EmailConfirmed = true;
            db.SaveChanges();
        }
    }
}
