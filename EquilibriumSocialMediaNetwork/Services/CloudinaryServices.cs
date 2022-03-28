using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Data;
using Data.Entities;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CloudinaryServices : ICloudinaryServices
    {
        private EquilibriumDbContext db;
        private Account account;
        private Cloudinary cloudinary;

        public CloudinaryServices(EquilibriumDbContext db)
        {
            this.db = db;

            account = new Account(
                "dwwp1raua",
                "831167528144154",
                "I_OBjKDBaJn6JCDGZkkKubfAnzQ");

            cloudinary = new Cloudinary(account);
        }

        public void DeleteImage(string publicId)
        {
            if (publicId == null)
            {
                return;
            }

            DeletionParams param = new DeletionParams(publicId)
            {
                ResourceType = ResourceType.Image,
                PublicId = publicId
            };

            cloudinary.Destroy(param);
        }

        public string FindProfilePicturePublicIdById(string id)
        {
            ProfilePicture profilePicture = db.ProfilePictures.FirstOrDefault(p => p.Id == id);

            if (profilePicture == null)
            {
                return null;
            }

            return profilePicture.ImagePublicId;
        }

        public string FindQrCodePublicIdById(string id)
        {
            QrCode qrCode = db.QrCodes.FirstOrDefault(qr => qr.Id == id);

            if (qrCode == null)
            {
                return null;
            }

            return qrCode.PublicId;
        }

        public string GetDownloadLink(string url)
        {
            string[] arr = url.Split("/").Skip(2).ToArray();

            StringBuilder sb = new StringBuilder();

            sb.Append("https://");

            foreach (string item in arr)
            {
                if (item == "upload")
                {
                    sb.Append($"{item}/fl_attachment/");
                }
                else
                {
                    sb.Append($"{item}/");
                }
            }

            string result = sb.ToString();
            result = result.Remove(result.Length - 1);

            return result;
        }

        public string UploadImage(byte[] data, string path)
        {
            Stream stream = new MemoryStream(data);

            ImageUploadParams uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Guid.NewGuid().ToString(), stream),
                Folder = path,
                PublicId = Guid.NewGuid().ToString()
            };

            ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);

            string url = uploadResult.SecureUrl.AbsoluteUri;
            string id = uploadResult.PublicId;

            return $"{url}*{id}";
        }
    }
}
