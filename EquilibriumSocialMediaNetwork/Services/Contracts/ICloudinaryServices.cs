using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICloudinaryServices
    {
        /// <summary>
        /// Uploads image to cloudinary.
        /// </summary>
        /// <param name="data">Image as byte[]</param>
        /// <param name="path">Path to save the image: Social media images/Posts, Social media images/Qr codes, Social media images/Profile pictures</param>
        /// <returns></returns>
        string UploadImage(byte[] data, string path);

        void DeleteImage(string publicId);

        string GetDownloadLink(string url);
    }
}
