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
    public class ImageServices : IImageServices
    {
        private EquilibriumDbContext db;

        public ImageServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public ImageServiceModel AddImage(ImageServiceModel image)
        {
            db.Images.Add(image.ToImage());

            db.SaveChanges();

            return image;
        }

        public ImageServiceModel AddProfilePicture(ImageServiceModel profilePicture, User user)
        {
            db.Images.Add(profilePicture.ToImage());
            user.ProfilePictureId = profilePicture.Id;

            db.SaveChanges();

            return profilePicture;
        }

        public QrCodeServiceModel AddQrCode(QrCodeServiceModel qrCode, User user)
        {
            db.QrCodes.Add(qrCode.ToQrCode());
            user.QrCodeId = qrCode.Id;

            db.SaveChanges();

            return qrCode;
        }

        public QrCodeServiceModel GetQrCodeByUserId(string userId)
        {
            QrCode qrCode = db.QrCodes
                .FirstOrDefault(q => q.UserId == userId);

            if (qrCode != null)
            {
                return qrCode.ToQrCodeServiceModel();
            }

            return null;
        }

        public ImageServiceModel GetProfilePictureByUserId(string userId)
        {
            Image image = db.Images
                .FirstOrDefault(i => i.UserId == userId);

            if (image != null)
            {
                return image.ToImageServiceModel();
            }

            return null;
        }

        public async Task<byte[]> GetImageBytes(IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                byte[] img = memoryStream.ToArray();

                return img;
            }
        }

        public void DeleteImage(string imageId)
        {
            Image img = db.Images.FirstOrDefault(i => i.Id == imageId);

            if (img == null)
            {
                return;
            }

            db.Images.Remove(img);

            db.SaveChanges();
        }
    }
}
