using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProfilePictureServices : IProfilePictureServices
    {
        private EquilibriumDbContext db;

        public ProfilePictureServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public ProfilePictureServiceModel AddProfilePicture(ProfilePictureServiceModel image)
        {
            db.ProfilePictures.Add(image.ToProfilePicture());

            db.SaveChanges();

            return image;
        }

        public ProfilePictureServiceModel AddProfilePicture(ProfilePictureServiceModel profilePicture, User user)
        {
            db.ProfilePictures.Add(profilePicture.ToProfilePicture());
            user.ProfilePictureId = profilePicture.Id;

            db.SaveChanges();

            return profilePicture;
        }

        public ProfilePictureServiceModel GetProfilePictureByUserId(string userId)
        {
            ProfilePicture image = db.ProfilePictures
                .FirstOrDefault(i => i.UserId == userId);

            if (image != null)
            {
                return image.ToProfilePictureServiceModel();
            }

            return null;
        }

        public void DeleteProfilePicture(string imageId)
        {
            User user = db.Users.FirstOrDefault(u => u.ProfilePictureId == imageId);
            ProfilePicture image = db.ProfilePictures.FirstOrDefault(i => i.Id == imageId);

            if (image == null)
            {
                return;
            }

            user.ProfilePictureId = null;
            db.ProfilePictures.Remove(image);

            db.SaveChanges();
        }
    }
}
