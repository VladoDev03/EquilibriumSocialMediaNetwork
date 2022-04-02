using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Conversation : BaseEntity
    {
        public Conversation()
        {
            Id = Guid.NewGuid().ToString();
            Messages = new HashSet<Message>();
        }

        public string UserOneId { get; set; }

        public string UserTwoId { get; set; }

        public IEnumerable<Message> Messages { get; set; }
    }
}
