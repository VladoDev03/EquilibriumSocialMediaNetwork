using Data.ViewModels.Comment;
using Data.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.Post
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            Comments = new List<CommentViewModel>();
        }

        public string Id { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public string ImageUrl { get; set; }

        public string ImageDownloadUrl { get; set; }

        public string ImagePublicId { get; set; }

        public bool IsDownloadable { get; set; }

        public UserViewModel User { get; set; }

        public List<CommentViewModel> Comments { get; set; }
    }
}
