using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
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

        public string Image { get; set; }

        public UserViewModel User { get; set; }

        public List<CommentViewModel> Comments { get; set; }
    }
}
