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
    public interface IImageServices
    {
        ImageServiceModel AddImage(ImageServiceModel image);

        QrCodeServiceModel AddQrCode(QrCodeServiceModel qrCode, User user);

        ImageServiceModel AddProfilePicture(ImageServiceModel profilePicture, User user);

        QrCodeServiceModel GetQrCodeByUserId(string userId);

        ImageServiceModel GetProfilePictureByUserId(string userId);

        Task<byte[]> GetImageBytes(IFormFile file);

        void DeleteImage(string imageId);
    }
}
