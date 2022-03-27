using Services.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class QrCodeServiceModelMapper
    {
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
