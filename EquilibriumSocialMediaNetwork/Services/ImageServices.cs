using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Services.Contracts;
using Services.Mappers;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ImageServices : IImageServices
    {
        private EquilibriumDbContext db;

        public ImageServices(EquilibriumDbContext db)
        {
            this.db = db;
        }

        public ImageServiceModel AddImage(ImageServiceModel image)
        {
            db.Images.Add(image.ToImage());

            db.SaveChanges();

            return image;
        }

        public List<ImageServiceModel> GetAllImages()
        {
            List<ImageServiceModel> images = db.Images
                .Include(i => i.Post)
                .Select(i => i.ToImageServiceModel())
                .ToList();

            return images;
        }

        public ImageServiceModel GetImageById(string imageId)
        {
            ImageServiceModel image = db.Images
                .Include(i => i.Post)
                .FirstOrDefault(i => i.Id == imageId)
                .ToImageServiceModel();

            return image;
        }

        public ImageServiceModel GetImageByPublicId(string publicId)
        {
            ImageServiceModel image = db.Images
                .FirstOrDefault(i => i.ImagePublicId == publicId)
                .ToImageServiceModel();

            return image;
        }

        public ImageServiceModel GetPostImage(string postId)
        {
            ImageServiceModel image = db.Images
                .FirstOrDefault(i => i.PostId == postId)
                .ToImageServiceModel();

            return image;
        }

        public List<ImageServiceModel> GetUserImages(string userId)
        {
            List<ImageServiceModel> images = db.Images
                .Include(i => i.Post)
                .Where(i => i.Post.UserId == userId)
                .Select(i => i.ToImageServiceModel())
                .ToList();

            return images;
        }

        public void RemoveImage(string id)
        {
            Image imageToRemove = db.Images.FirstOrDefault(i => i.Id == id);

            if (imageToRemove != null)
            {
                db.Images.Remove(imageToRemove);
                db.SaveChanges();
            }
        }
    }
}
