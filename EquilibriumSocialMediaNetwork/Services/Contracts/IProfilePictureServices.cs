using Data.Entities;
using Microsoft.AspNetCore.Http;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IProfilePictureServices
    {
        /// <summary>
        /// Adds profile picture to the database.
        /// </summary>
        /// <param name="image">Profile picture to be added.</param>
        /// <returns>The added profile picture.</returns>
        ProfilePictureServiceModel AddProfilePicture(ProfilePictureServiceModel image);

        /// <summary>
        /// Sets the profile picture to the given user.
        /// </summary>
        /// <param name="profilePicture">The profile picture of the user.</param>
        /// <param name="user">The user that the profiles picture is being set to.</param>
        /// <returns>Returns the profile picture.</returns>
        ProfilePictureServiceModel AddProfilePicture(ProfilePictureServiceModel profilePicture, User user);

        /// <summary>
        /// Gets the profile picture of the given user.
        /// </summary>
        /// <param name="userId">Id of the user.</param>
        /// <returns>The user's profile picture.</returns>
        ProfilePictureServiceModel GetProfilePictureByUserId(string userId);

        /// <summary>
        /// Removes the given profile picture from the database.
        /// </summary>
        /// <param name="imageId">The profile picture's id.</param>
        void DeleteProfilePicture(string imageId);
    }
}
