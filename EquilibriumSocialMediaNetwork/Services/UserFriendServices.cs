using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
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
    public class UserFriendServices : IUserFriendServices
    {
        private EquilibriumDbContext db;

        public UserFriendServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public List<UserFriendServiceModel> GetUserFriends(string userId)
        {
            List<UserFriendServiceModel> friends = db.UsersFriends
                .Include(f => f.Friend)
                .Where(f => f.UserId == userId)
                .Select(f => f.ToUserFriendServiceModel())
                .ToList();

            return friends;
        }

        public void RemoveUserFriend(string userId, string friendId)
        {
            UserFriend friendToRemove = db.UsersFriends
                .FirstOrDefault(fr => fr.UserId == userId && fr.FriendId == friendId);

            UserFriend userToRemove = db.UsersFriends
                .FirstOrDefault(fr => fr.UserId == friendId && fr.FriendId == userId);

            db.UsersFriends.Remove(friendToRemove);
            db.UsersFriends.Remove(userToRemove);

            db.SaveChanges();
        }
    }
}
