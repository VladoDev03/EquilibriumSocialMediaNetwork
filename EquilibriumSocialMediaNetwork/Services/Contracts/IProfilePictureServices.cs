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
        ProfilePictureServiceModel AddProfilePicture(ProfilePictureServiceModel image);

        ProfilePictureServiceModel AddProfilePicture(ProfilePictureServiceModel profilePicture, User user);

        ProfilePictureServiceModel GetProfilePictureByUserId(string userId);

        void DeleteProfilePicture(string imageId);
    }
}
