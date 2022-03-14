using Data.Entities;
using Data.ViewModels.Image;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class ImageServiceModelMapper
    {
        public static ImageServiceModel ToImageServiceModel(this Image image)
        {
            ImageServiceModel result = new ImageServiceModel()
            {
                Id = image.Id,
                ImageDownloadUrl = image.ImageDownloadUrl,
                ImageUrl = image.ImageUrl,
                ImagePublicId = image.ImagePublicId,
                IsDownloadable = image.IsDownloadable,
                //Post = image.Post.ToPostServiceModel(),
                PostId = image.PostId
            };

            return result;
        }

        public static Image ToImage(this ImageServiceModel image)
        {
            Image result = new Image()
            {
                Id = image.Id,
                ImageDownloadUrl = image.ImageDownloadUrl,
                ImageUrl = image.ImageUrl,
                ImagePublicId = image.ImagePublicId,
                IsDownloadable = image.IsDownloadable,
                //Post = image.Post.ToPost(),
                PostId = image.PostId
            };

            return result;
        }

        public static ImageViewModel ToImageViewModel(this ImageServiceModel image)
        {
            ImageViewModel result = new ImageViewModel()
            {
                Id = image.Id,
                ImageDownloadUrl = image.ImageDownloadUrl,
                ImageUrl = image.ImageUrl,
                ImagePublicId = image.ImagePublicId,
                IsDownloadable = image.IsDownloadable,
                //Post = image.Post.ToPostViewModel(),
                PostId = image.PostId
            };

            return result;
        }
    }
}
