using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IAdminServices
    {
        /// <summary>
        /// Deletes the profile of the given user.
        /// </summary>
        /// <param name="userId">Id of the user that is going to be deleted.</param>
        void DeleteUserProfile(string userId);
    }
}
