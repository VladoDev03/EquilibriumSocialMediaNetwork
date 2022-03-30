using Data;
using Data.Entities;
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
            return db.Users
                .FirstOrDefault(u => u.Id == id)
                .ToUserServiceModel();
        }

        public void DeleteUser(string userId)
        {
            User userToRemove = db.Users.FirstOrDefault(u => u.Id == userId);

            db.Users.Remove(userToRemove);

            db.SaveChanges();
        }
    }
}
