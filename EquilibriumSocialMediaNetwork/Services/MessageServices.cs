using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Mappers;
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

        public MessageServiceModel AddMessage(MessageServiceModel message)
        {
            message.TimeSent = DateTime.Now;
            db.Messages.Add(message.ToMessage());

            db.SaveChanges();

            return message;
        }

        public List<MessageServiceModel> GetAllMessages()
        {
            List<MessageServiceModel> messages = db.Messages
                .Include(m => m.UserOne)
                .Include(m => m.UserTwo)
                .Select(m => m.ToMessageServiceModel())
                .ToList();

            return messages;
        }

        public MessageServiceModel GetMessageById(string id)
        {
            MessageServiceModel message = db.Messages
                .Include(m => m.UserOne)
                .Include(m => m.UserTwo)
                .FirstOrDefault(m => m.Id == id)
                .ToMessageServiceModel();

            return message;
        }

        public void DeleteAllUserMessages(string userId)
        {
            List<Message> messagesToDelete = db.Messages
                .Where(m => m.UserOneId == userId || m.UserTwoId == userId)
                .ToList();

            db.Messages.RemoveRange(messagesToDelete);
            db.SaveChanges();
        }

        public void RemoveMessage(string messageId)
        {
            Message message = db.Messages.FirstOrDefault(m => m.Id == messageId);

            db.Messages.Remove(message);

            db.SaveChanges();
        }
    }
}
