using Services.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class ImageServiceModelMapper
    {
        public static ImageServiceModel ToImageServiceModel(this Image image)
        {
            ImageServiceModel result = new ImageServiceModel()
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

        public static Image ToImage(this ImageServiceModel image)
        {
            Image result = new Image()
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

        public static QrCodeServiceModel ToQrCodeServiceModel(this QrCode qrCode)
        {
            QrCodeServiceModel result = new QrCodeServiceModel()
            {
                Id = qrCode.Id,
                ImageDownloadUrl = qrCode.ImageDownloadUrl,
                ImageUrl = qrCode.ImageUrl,
                UserId = qrCode.UserId
            };

            return result;
        }

        public static QrCode ToQrCode(this QrCodeServiceModel qrCode)
        {
            QrCode result = new QrCode()
            {
                Id = qrCode.Id,
                ImageDownloadUrl = qrCode.ImageDownloadUrl,
                ImageUrl = qrCode.ImageUrl,
                UserId = qrCode.UserId
            };

            return result;
        }
    }
}
