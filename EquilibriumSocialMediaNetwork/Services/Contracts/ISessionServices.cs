using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISessionServices
    {
        /// <summary>
        /// Gets current session of a given user.
        /// </summary>
        /// <param name="userId">User's id.</param>
        /// <returns>Session's id.</returns>
        string GetSession(string userId);

        /// <summary>
        /// Adds a session to the sessions dictionary by user' id and connection's id.
        /// </summary>
        /// <param name="connectionId">The connection's id.</param>
        /// <param name="userId">The user's id.</param>
        void AddSession(string connectionId, string userId);
    }
}
