using Data;
using Data.Entities;
using Services.Contracts;
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

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }
    }
}
