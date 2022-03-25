using Data;
using Data.Entities;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
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

        public ImageServiceModel AddProfilePictureToUser(ImageServiceModel profilePicture, User user)
        {
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
    }
}
