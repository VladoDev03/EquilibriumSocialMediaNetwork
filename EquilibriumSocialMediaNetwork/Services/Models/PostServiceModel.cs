using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PostServiceModel : BaseEntityServiceModel
    {
        public PostServiceModel()
        {
            Comments = new HashSet<CommentServiceModel>();
            Reactions = new HashSet<ReactionServiceModel>();
        }

        public string Content { get; set; }

        public string Image { get; set; }

        public bool IsDownloadable { get; set; }

        public virtual ICollection<CommentServiceModel> Comments { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<ReactionServiceModel> Reactions { get; set; }
    }
}
