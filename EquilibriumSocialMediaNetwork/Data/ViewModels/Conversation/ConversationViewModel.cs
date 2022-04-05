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
            string userTwoUserName,
            string userTwoFirstName,
            string userTwoLastName,
            string conversationId)
        {
            UserOneId = userOneId;
            UserTwoId = userTwoId;
            ConversationId = conversationId;
            UserTwoUserName = userTwoUserName;
            UserTwoFirstName = userTwoFirstName;
            UserTwoLastName = userTwoLastName;
        }

        public string UserOneId { get; set; }

        public string UserTwoId { get; set; }

        public string UserTwoUserName { get; set; }

        public string UserTwoFirstName { get; set; }

        public string UserTwoLastName { get; set; }

        public string ConversationId { get; set; }
    }
}
