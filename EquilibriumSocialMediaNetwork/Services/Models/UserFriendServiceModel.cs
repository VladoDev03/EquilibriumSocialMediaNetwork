using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class UserFriendServiceModel : BaseEntityServiceModel
    {
        public string UserId { get; set; }

        public string FriendId { get; set; }

        public User User { get; set; }

        public User Friend { get; set; }
    }
}
