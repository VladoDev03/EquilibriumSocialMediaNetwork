using Data.Entities;
using Data.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.User
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Posts = new List<PostViewModel>();
        }

        public string Id { get; set; }

        public string LoggedUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public bool CanSendInvitation { get; set; }

        public bool IsAdmin { get; set; }

        public ProfilePictureViewModel ProfilePicture { get; set; }

        public List<PostViewModel> Posts { get; set; }
    }
}
