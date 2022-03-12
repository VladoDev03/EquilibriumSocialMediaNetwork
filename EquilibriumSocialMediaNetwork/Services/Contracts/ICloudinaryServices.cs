using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ICloudinaryServices
    {
        string UploadImage(byte[] data);

        void DeleteImage(string publicId);

        string GetDownloadLink(string url);
    }
}
