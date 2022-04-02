using Data.Entities;
using Data.ViewModels;
using Data.ViewModels.Post;
using Data.ViewModels.User;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappers
{
    public static class UserServiceModelMapper
    {
        public static UserServiceModel ToUserServiceModel(this User user)
        {
            UserServiceModel result = new UserServiceModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                ProfilePictureId = user.ProfilePictureId,
                QrCodeId = user.QrCodeId
            };

            return result;
        }

        public static User ToUser(this UserServiceModel user)
        {
            User result = new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                ProfilePictureId = user.ProfilePictureId,
                QrCodeId = user.QrCodeId
            };

            return result;
        }

        public static User ToUser(this UserViewModel user)
        {
            User result = new User()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName
            };

            return result;
        }

        public static UserViewModel ToUserViewModel(this UserServiceModel user)
        {
            UserViewModel result = new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Posts = new List<PostViewModel>()
            };

            return result;
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            UserViewModel result = new UserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Posts = new List<PostViewModel>()
            };

            return result;
        }
    }
}
