using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class FriendRequestServiceModel : BaseEntityServiceModel
    {
        public string RequestStatus { get; set; }

        public string RequestedFromId { get; set; }

        public string RequestedToId { get; set; }

        public User RequestedFrom { get; set; }

        public User RequestedTo { get; set; }
    }
}
