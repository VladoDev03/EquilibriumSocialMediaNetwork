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

namespace Services
{
    public class QrCodeServices : IQrCodeServices
    {
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
    }
}
