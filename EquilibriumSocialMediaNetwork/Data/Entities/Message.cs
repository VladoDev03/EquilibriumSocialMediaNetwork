using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Message : BaseEntity
    {
        public Message()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Content { get; set; }

        public string ConversationId { get; set; }

        public string UserOneId { get; set; }

        public string UserTwoId { get; set; }

        public Conversation Conversation { get; set; }

        public User UserOne { get; set; }

        public User UserTwo { get; set; }
    }
}
