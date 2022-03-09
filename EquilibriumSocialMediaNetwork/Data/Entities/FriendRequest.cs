using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FriendRequest : BaseEntity
    {
        public string RequestStatus { get; set; }

        public string RequestedFromId { get; set; }

        public string RequestedToId { get; set; }

        public User RequestedFrom { get; set; }

        public User RequestedTo { get; set; }
    }
}
