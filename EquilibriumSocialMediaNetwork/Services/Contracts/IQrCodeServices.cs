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
        /// <summary>
        /// Creates byte array from the given data.
        /// </summary>
        /// <param name="content">The data that is used for the qr code.</param>
        /// <returns>Qr code generated from the given data.</returns>
        byte[] MakeQrCode(string content);

        /// <summary>
        /// Sets the qr code to the given user.
        /// </summary>
        /// <param name="qrCode">Qr code to be set to the user.</param>
        /// <param name="user">User to whom the qr code is set to.</param>
        /// <returns>The updated qr code.</returns>
        QrCodeServiceModel AddQrCode(QrCodeServiceModel qrCode, User user);

        /// <summary>
        /// Gets the qr code of the given user's id.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>The qr code.</returns>
        QrCodeServiceModel GetQrCodeByUserId(string userId);

        /// <summary>
        /// Converts the input image to byte array.
        /// </summary>
        /// <param name="file">The user's input.</param>
        /// <returns>The generated image.</returns>
        Task<byte[]> GetImageBytes(IFormFile file);

        /// <summary>
        /// Removes qr code from the database.
        /// </summary>
        /// <param name="id"></param>
        void DeleteQrCode(string id);
    }
}
