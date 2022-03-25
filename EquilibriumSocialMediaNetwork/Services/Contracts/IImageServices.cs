using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IImageServices
    {
        ImageServiceModel AddImage(ImageServiceModel image);

        QrCodeServiceModel AddQrCode(QrCodeServiceModel qrCode, User user);

        ImageServiceModel AddProfilePictureToUser(ImageServiceModel profilePicture, User user);

        QrCodeServiceModel GetQrCodeByUserId(string userId);
    }
}
