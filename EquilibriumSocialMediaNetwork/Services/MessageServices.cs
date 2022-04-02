using Data;
using Services.Contracts;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MessageServices : IMessageServices
    {
        private EquilibriumDbContext db;

        public MessageServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public MessageServiceModel AddMessage()
        {
            throw new NotImplementedException();
        }

        public List<MessageServiceModel> GetAllMessages()
        {
            throw new NotImplementedException();
        }

        public MessageServiceModel GetMessageById()
        {
            throw new NotImplementedException();
        }
    }
}
