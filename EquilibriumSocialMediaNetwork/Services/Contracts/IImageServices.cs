using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IImageServices
    {
        ImageServiceModel AddImage(ImageServiceModel image);

        List<ImageServiceModel> GetAllImages();

        List<ImageServiceModel> GetUserImages(string userId);

        ImageServiceModel GetPostImage(string postId);

        ImageServiceModel GetImageById(string imageId);

        ImageServiceModel GetImageByPublicId(string publicId);

        void RemoveImage(string id);
    }
}
