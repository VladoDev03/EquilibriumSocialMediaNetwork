using QRCoder;
using Services.Contracts;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Data;
using Services.Mappers;

namespace Services
{
    public class QrCodeServices : IQrCodeServices
    {
        private EquilibriumDbContext db;

        public QrCodeServices(EquilibriumDbContext db)
        {
            this.db = db;
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

        public byte[] MakeQrCode(string content)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator gen = new QRCodeGenerator();
                QRCodeData myData = gen.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(myData);

                using (Bitmap map = code.GetGraphic(20))
                {
                    map.Save(ms, ImageFormat.Png);
                }

                byte[] finalImage = ms.ToArray();

                return finalImage;
            }
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
    }
}
