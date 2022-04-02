using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISessionServices
    {
        string GetSession(string userId);

        void AddSession(string connectionId, string userId);
    }
}
