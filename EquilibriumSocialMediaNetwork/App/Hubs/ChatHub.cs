using Microsoft.AspNetCore.SignalR;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ISessionServices service;

        public ChatHub(ISessionServices service)
        {
            this.service = service;
        }

        public override Task OnConnectedAsync()
        {
            throw new NotImplementedException();
        }

        public override Task OnDisconnectedAsync(System.Exception exception)
        {
            throw new NotImplementedException();
        }

        public async Task SendMessage(string id1, string id2, string message)
        {
            throw new NotImplementedException();
        }
    }
}
