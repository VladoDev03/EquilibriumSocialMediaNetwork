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
    public interface IQrCodeServices
    {
        byte[] MakeQrCode(string content);

        QrCodeServiceModel AddQrCode(QrCodeServiceModel qrCode, User user);

        QrCodeServiceModel GetQrCodeByUserId(string userId);

        Task<byte[]> GetImageBytes(IFormFile file);

        void DeleteQrCode(string id);
    }
}
