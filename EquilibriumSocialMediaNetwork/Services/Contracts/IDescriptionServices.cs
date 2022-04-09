using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDescriptionServices
    {
        /// <summary>
        /// Adds user's description to database.
        /// </summary>
        /// <param name="description">The description we want to add.</param>
        /// <returns>The description that has just been added.</returns>
        DescriptionServiceModel AddDescription(DescriptionServiceModel description);

        /// <summary>
        /// Updates description.
        /// </summary>
        /// <param name="updatedDescription">The new data of the description.</param>
        /// <returns>The updated description.</returns>
        DescriptionServiceModel UpdateDescription(DescriptionServiceModel updatedDescription);

        /// <summary>
        /// Removes description by it's id.
        /// </summary>
        /// <param name="id">Id of the description.</param>
        void DeleteDescription(string id);
    }
}
