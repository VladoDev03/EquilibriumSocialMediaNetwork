using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class ChatController
    {
        private IMessageServices messageServices;
        private IConversationServices conversationServices;

        public ChatController(
            IMessageServices messageServices,
            IConversationServices conversationServices)
        {
            this.messageServices = messageServices;
            this.conversationServices = conversationServices;
        }

        [HttpGet]
        public IActionResult AllChats()
        {
            throw new NotImplementedException();
        }

        public IActionResult Chat()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Messages()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Conversation(string username)
        {
            throw new NotImplementedException();
        }
    }
}
