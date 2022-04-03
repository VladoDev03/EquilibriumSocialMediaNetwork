using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class MessageServiceModelMapper
    {
        public static Message ToMessage(this MessageServiceModel message)
        {
            Message result = new Message()
            {
                Id = message.Id,
                Content = message.Content,
                UserOneId = message.UserOneId,
                UserTwoId = message.UserTwoId,
                ConversationId = message.ConversationId,
                UserOne = message.UserOne,
                UserTwo = message.UserTwo
            };

            return result;
        }

        public static MessageServiceModel ToMessageServiceModel(this Message message)
        {
            MessageServiceModel result = new MessageServiceModel()
            {
                Id = message.Id,
                Content = message.Content,
                UserOneId = message.UserOneId,
                UserTwoId = message.UserTwoId,
                ConversationId = message.ConversationId,
                UserOne = message.UserOne,
                UserTwo = message.UserTwo
            };

            return result;
        }
    }
}
