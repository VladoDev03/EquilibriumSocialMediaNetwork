using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Data;
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
        private Account account;
        private Cloudinary cloudinary;

        public CloudinaryServices()
        {
            account = new Account(
                "dwwp1raua",
                "831167528144154",
                "I_OBjKDBaJn6JCDGZkkKubfAnzQ");

            cloudinary = new Cloudinary(account);
        }

        public void DeleteImage(string publicId)
        {
            DeletionParams param = new DeletionParams(publicId)
            {
                ResourceType = ResourceType.Image,
            };

            cloudinary.Destroy(param);
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

        public string UploadImage(byte[] data)
        {
            Stream stream = new MemoryStream(data);

            ImageUploadParams uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(Guid.NewGuid().ToString(), stream),
                Folder = "User posts",
                PublicId = Guid.NewGuid().ToString()
            };

            ImageUploadResult uploadResult = cloudinary.Upload(uploadParams);

            string url = uploadResult.SecureUrl.AbsoluteUri;
            string id = uploadResult.PublicId;

            return $"{url}*{id}";
        }
    }
}
