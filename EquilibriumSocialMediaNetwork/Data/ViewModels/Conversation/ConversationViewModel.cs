using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Conversation
{
    public class ConversationViewModel
    {
        public ConversationViewModel(
            string userOneId,
            string userTwoId,
            string conversationId)
        {
            UserOneId = userOneId;
            UserTwoId = userTwoId;
            ConversationId = conversationId;
        }

        public string UserOneId { get; set; }

        public string UserTwoId { get; set; }

        public string ConversationId { get; set; }
    }
}
