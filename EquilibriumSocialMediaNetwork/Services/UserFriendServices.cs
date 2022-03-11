using Data;
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
    }
}
