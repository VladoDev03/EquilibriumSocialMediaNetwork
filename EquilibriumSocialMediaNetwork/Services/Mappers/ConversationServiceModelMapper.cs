using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class ConversationServiceModelMapper
    {
        public static Conversation ToConversation(this ConversationServiceModel conversation)
        {
            Conversation result = new Conversation()
            {
                Id = conversation.Id,
                Messages = conversation.Messages.Select(m => m.ToMessage()),
                UserOneId = conversation.UserOneId,
                UserTwoId = conversation.UserTwoId
            };

            return result;
        }

        public static ConversationServiceModel ToConversationServiceModel(this Conversation conversation)
        {
            ConversationServiceModel result = new ConversationServiceModel()
            {
                Id = conversation.Id,
                Messages = conversation.Messages.Select(m => m.ToMessageServiceModel()),
                UserOneId = conversation.UserOneId,
                UserTwoId = conversation.UserTwoId
            };

            return result;
        }
    }
}
