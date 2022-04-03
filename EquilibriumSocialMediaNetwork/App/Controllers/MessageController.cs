using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Linq;

namespace App.Controllers
{
    public class MessageController : Controller
    {
        private IMessageServices messageServices;

        public MessageController(IMessageServices messageServices)
        {
            this.messageServices = messageServices;
        }

        [HttpGet("messages")]
        public IActionResult Index()
        {
            return Ok(messageServices
                .GetAllMessages()
                .Select(message => new
                {
                    Content = message.Content,
                    UsernameOne = message.UserOne.UserName,
                    UsernameTwo = message.UserTwo.UserName,
                })
                .ToList());
        }
    }
}
