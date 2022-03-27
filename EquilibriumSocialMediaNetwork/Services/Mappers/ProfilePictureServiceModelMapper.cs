using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class ProfilePictureServiceModelMapper
    {
        public static ProfilePictureServiceModel ToProfilePictureServiceModel(this ProfilePicture image)
        {
            ProfilePictureServiceModel result = new ProfilePictureServiceModel()
            {
                Id = image.Id,
                ImageDownloadUrl = image.ImageDownloadUrl,
                ImagePublicId = image.ImagePublicId,
                ImageUrl = image.ImageUrl,
                IsDownloadable = image.IsDownloadable,
                UserId = image.UserId
            };

            return result;
        }

        public static ProfilePicture ToProfilePicture(this ProfilePictureServiceModel image)
        {
            ProfilePicture result = new ProfilePicture()
            {
                Id = image.Id,
                ImageDownloadUrl = image.ImageDownloadUrl,
                ImagePublicId = image.ImagePublicId,
                ImageUrl = image.ImageUrl,
                IsDownloadable = image.IsDownloadable,
                UserId = image.UserId
            };

            return result;
        }
    }
}
