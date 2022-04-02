using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SessionServices : ISessionServices
    {
        private Dictionary<string, string> userSessions;

        public SessionServices()
        {
            userSessions = new Dictionary<string, string>();
        }

        public void AddSession(string connectionId, string userId)
        {
            userSessions[userId] = connectionId;
        }

        public string GetSession(string userId)
        {
            return userSessions.ContainsKey(userId) ? userSessions[userId] : null;
        }
    }
}
