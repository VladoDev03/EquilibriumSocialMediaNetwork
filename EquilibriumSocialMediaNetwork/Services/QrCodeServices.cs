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
            return new byte[0];
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

        public void DeleteQrCode(string id)
        {
            QrCode qrCode = db.QrCodes.FirstOrDefault(qr => qr.Id == id);

            if (qrCode != null)
            {
                db.QrCodes.Remove(qrCode);

                db.SaveChanges();
            }
        }
    }
}
