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
        /// <param name="data">Image as byte[].</param>
        /// <param name="path">Path to save the image: Social media images/Posts, Social media images/Qr codes, Social media images/Profile pictures.</param>
        /// <returns>Public id and url to Cloudinary of the uploaded image.</returns>
        string UploadImage(byte[] data, string path);

        /// <summary>
        /// Deletes image from Cloudinary.
        /// </summary>
        /// <param name="publicId">Public id of the image that is going to be deleted.</param>
        void DeleteImage(string publicId);

        /// <summary>
        /// Generates link that can be used to download an image from Cloudinary.
        /// </summary>
        /// <param name="url">Url of the image.</param>
        /// <returns>Url that can be used in order to download an image.</returns>
        string GetDownloadLink(string url);

        /// <summary>
        /// Finds the public id of a qr code by its id.
        /// </summary>
        /// <param name="id">The id, in the database, of the qr code.</param>
        /// <returns>Qr code's public id.</returns>
        string FindQrCodePublicIdById(string id);

        /// <summary>
        /// Finds the public id of a profile picture by its id.
        /// </summary>
        /// <param name="id">The id, in the database, of the profile picture.</param>
        /// <returns>Profile picture's public id.</returns>
        string FindProfilePicturePublicIdById(string id);
    }
}
