using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IMessageServices
    {
        List<MessageServiceModel> GetAllMessages();

        MessageServiceModel GetMessageById(string id);

        MessageServiceModel AddMessage(MessageServiceModel message);

        void RemoveMessage(string messageId);

        void DeleteAllUserMessages(string userId);
    }
}
